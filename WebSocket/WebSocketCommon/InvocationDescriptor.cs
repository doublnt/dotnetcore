using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WebSocketCommon
{
    public class InvocationDescriptor
    {
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonProperty("arguments")]
        public object[] Arguments { get; set; }
    }
}
