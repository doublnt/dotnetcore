using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DeserializeJsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "../../../endpoints.json";

            var dictionary = new Dictionary<string, Dictionary<string, string>>();

            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var job = JObject.Parse(json);
                foreach (var item in job.Properties())
                {
                    var endPointsList = new Dictionary<string, string>();
                    foreach (var productItem in item.Value)
                    {
                        var domain = (string)((JValue)((JProperty)productItem).Value).Value;
                        var regionId = ((JProperty)(productItem)).Name;
                        endPointsList.Add(regionId, domain);
                    }

                    dictionary.Add(item.Name, endPointsList);
                }

                Console.WriteLine("Hello!!!!!!");
            }
        }
    }
}