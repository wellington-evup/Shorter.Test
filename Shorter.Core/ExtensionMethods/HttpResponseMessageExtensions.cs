using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shorter.Core.ExtensionMethods
{
    public static class HttpResponseMessageExtensions
    {
        public async static Task<JObject> ConvertToJObject(this HttpResponseMessage message)
        {
            var a = await GetContent(message);
            return JObject.Parse(a);
        }

        public async static Task<JsonString> ConvertToJsonString(this HttpResponseMessage message)
        {
            var a = await GetContent(message);
            return new JsonString(a);
        }

        public async static Task<T> ConvertResult<T>(this HttpResponseMessage message)
        {
            var a = await GetContent(message);
            return JsonConvert.DeserializeObject<T>(a);
        }

        private async static Task<string> GetContent(this HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
                throw new Exception("httpError status: "+ message.StatusCode);

            var a = await message.Content.ReadAsStringAsync();
            return a;
        }
    }
}
