using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AliyunSignatureDemo
{
    internal class Program
    {
        private const string EcsUrl = "rds.aliyuncs.com";

        private const string _splitStr = "&";
        private const string ENCODING_UTF8 = "UTF-8";
        private static readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> _queries = new Dictionary<string, string>();

        private static readonly string _accessKeyId = Environment.GetEnvironmentVariable("ACCESS_KEY_ID");
        private static string _accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET");

        private static void Main(string[] args)
        {
            RpcQueries();
            RpcHeaders();

            var stringToSign = ComposeStringToSign();
            var signature = ComputeSignature(stringToSign, _accessKeySecret + "&");

            _queries.TryAdd("Signature", signature);

            var url = ComposeUrl(EcsUrl, _queries);

            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

            foreach (var item in _headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }

            var response = request.GetResponse() as HttpWebResponse;

            using (var memoryStream = new MemoryStream())
            {
                var buffer = new byte[1024];
                var stream = response.GetResponseStream();

                while (true)
                {
                    var length = stream.Read(buffer, 0, 1024);
                    if (length == 0)
                    {
                        break;
                    }

                    memoryStream.Write(buffer, 0, length);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                var bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, bytes.Length);

                stream.Close();
                stream.Dispose();

                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }
        }

        private static string ComposeUrl(string endpoint, Dictionary<string, string> queries)
        {
            var urlBuilder = new StringBuilder("");
            urlBuilder.Append("http");
            urlBuilder.Append("://").Append(endpoint);
            if (-1 == urlBuilder.ToString().IndexOf("?"))
            {
                urlBuilder.Append("/?");
            }

            var query = ConcatQueryString(queries);
            return urlBuilder.Append(query).ToString();
        }

        private static string ConcatQueryString(Dictionary<string, string> parameters)
        {
            if (null == parameters)
            {
                return null;
            }

            var sb = new StringBuilder();

            foreach (var entry in parameters)
            {
                var key = entry.Key;
                var val = entry.Value;

                sb.Append(HttpUtility.UrlEncode(key, Encoding.UTF8));
                if (val != null)
                {
                    sb.Append("=").Append(HttpUtility.UrlEncode(val, Encoding.UTF8));
                }

                sb.Append("&");
            }

            var strIndex = sb.Length;
            if (parameters.Count > 0)
            {
                sb.Remove(strIndex - 1, 1);
            }

            return sb.ToString();
        }

        private static void RpcHeaders()
        {
            _headers.Add("x-sdk-client", "Net/2.0.0");
            _headers.Add("x-sdk-invoke-type", "normal");
            _headers.Add("User-Agent", "User-Agent, Alibaba Cloud (Microsoft Windows 10.0.18362 ) netcoreapp/2.0.9 Core/1.5.1.0");
        }

        private static void RpcQueries()
        {
            var version = "2014-08-15";
            var action = "DescribeRegions";

            _queries.TryAdd("Action", action);
            _queries.TryAdd("Version", version);
            _queries.TryAdd("Format", "JSON");
            var timeStamp = FormatIso8601Date(DateTime.Now);
            var signatureMethod = "HMAC-SHA1";
            var signatureVersion = "1.0";
            var signatureNonce = Guid.NewGuid().ToString();

            _queries.TryAdd("RegionId", "cn-hangzhou");
            _queries.TryAdd("Timestamp", timeStamp);
            _queries.TryAdd("SignatureMethod", signatureMethod);
            _queries.TryAdd("SignatureVersion", signatureVersion);
            _queries.TryAdd("SignatureNonce", signatureNonce);
            _queries.TryAdd("AccessKeyId", _accessKeyId);
            _queries.TryAdd("ServiceCode", "rds");
            _queries.TryAdd("Type", "openAPI");
            _queries.TryAdd("id", "cn-hangzhou");
        }

        private static string ComputeSignature(string stringToSign, string accessKeySecret)
        {
            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(accessKeySecret)))
            {
                var hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
                return Convert.ToBase64String(hashValue);
            }
        }


        private static string ComposeStringToSign()
        {
            var tempQueries = new Dictionary<string, string>(_queries);

            var sortedDictionary = new SortedDictionary<string, string>(tempQueries, StringComparer.Ordinal);
            var headerQueryString = new StringBuilder();

            foreach (var item in sortedDictionary)
            {
                headerQueryString.Append(_splitStr)
                    .Append(PercentEncode(item.Key))
                    .Append("=")
                    .Append(PercentEncode(item.Value));
            }

            var stringToSign = new StringBuilder();
            stringToSign.Append("GET");
            stringToSign.Append(_splitStr);
            stringToSign.Append(PercentEncode("/"));
            stringToSign.Append(_splitStr);
            stringToSign.Append(PercentEncode(headerQueryString.ToString().Substring(1)));

            return stringToSign.ToString();
        }

        private static string PercentEncode(string value)
        {
            var stringBuilder = new StringBuilder();
            var text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            var bytes = Encoding.GetEncoding(ENCODING_UTF8).GetBytes(value);
            foreach (char c in bytes)
            {
                if (text.IndexOf(c) >= 0)
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    stringBuilder.Append("%").Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)c));
                }
            }

            return stringBuilder.ToString();
        }

        private static string FormatIso8601Date(DateTime date)
        {
            var ISO8601_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss'Z'";

            return date.ToUniversalTime()
                .ToString(ISO8601_DATE_FORMAT, CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}
