using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shorter.Core.Helpers
{
    public static class ApiHelper
    {
        public async static Task<HttpResponseMessage> ExecutePost(ApiRequest request)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                if (request.AccessTokenProvider != null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {request.AccessTokenProvider.Get()}");
                }
                var requestResult = await client.PostAsync(request.Endpoint, request.RequestObject);
                return requestResult;
            }
        }

        public async static Task<HttpResponseMessage> ExecuteGet()
        {
            using (var client = new HttpClient())
            {
                var requestResult = await client.GetAsync(@"https://func-dev-leadpage-el.azurewebsites.net/api/espacolaser/pt-BR/GetEstablishments?lat=-23.164471799999998&lng=-47.039723&code=yeJCx8KT6gsYS071sQkuYepTt/9LbJ4t3AKcDSu0jkOg80iayJz2rg==");
                return requestResult;
            }
        }
    }
}
