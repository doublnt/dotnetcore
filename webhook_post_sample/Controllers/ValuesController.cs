using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using webhook_post_sample.Model;

namespace webhook_post_sample.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<string> DocFileList = new List<string>();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // POST api/values
        [HttpPost("/payload")]
        public async Task<string> Post()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    await DeserializeJsonFromStream(streamReader);

                    return await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task DeserializeJsonFromStream(StreamReader streamReader)
        {
            var json = await streamReader.ReadToEndAsync();
            var job = JObject.Parse(json);

            IList<JToken> results = job["commits"].Children().ToList();
            IList<WebhookCommit> webhookCommitsList = new List<WebhookCommit>();

            foreach (var result in results)
            {
                var commits = result.ToObject<WebhookCommit>();
                webhookCommitsList.Add(commits);
            }

            AddChangeFileToList(webhookCommitsList);

            DownLoadFileToLocal(DocFileList);
        }

        private void AddChangeFileToList(IList<WebhookCommit> commits)
        {
            foreach (var item in commits)
            {
                AddDownloadFileToList(item.Added);
                AddDownloadFileToList(item.Modified);
            }
        }

        private void AddDownloadFileToList(IList<string> docList)
        {
            foreach (var item in docList)
            {
                if (DocFileList.Contains(item)) continue;

                DocFileList.Add(item);
            }
        }

        private async void DownLoadFileToLocal(IList<string> docList)
        {
            string baseUrl = "https://raw.githubusercontent.com/doublnt/dotnetcore/master/";
            string homeDirectory = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var targetDirectory = homeDirectory;
            Directory.CreateDirectory(targetDirectory + "/Docs/");

            using (WebClient webClient = new WebClient())
            {
                foreach (var file in docList)
                {
                    var fileName = new Uri(baseUrl + file);

                    await webClient.DownloadFileTaskAsync(fileName, targetDirectory + "/" + file);
                }
            }
        }

        // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // { }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // { }
    }
}
