using Shorter.Core.ExtensionMethods;
using Shorter.Core.Helpers;
using System.Net.Http;

namespace Shorter.Core
{
    public class MainAccessTokenProvider : AccessTokenProvider
    {
        public override AccessToken Get()
        {
            var dict = new System.Collections.Generic.Dictionary<string, string>();
            dict.Add("grant_type", "client_credentials");
            dict.Add("client_id", "shared:default");
            dict.Add("client_secret", "mvk3ll2imzjvmoeqxwxexxkwiimprrkvz0x7saluqsmx");
            dict.Add("scope", "squidex-api");

            var apiRequest = new ApiRequest()
            {
                Endpoint = "https://cms-dev.evup.com.br/identity-server/connect/token",
                RequestObject = new FormUrlEncodedContent(dict)
            };
            return new AccessToken(ApiHelper.ExecutePost(apiRequest).Result.ConvertToJObject().Result["access_token"].ToString());
        }
    }
}
