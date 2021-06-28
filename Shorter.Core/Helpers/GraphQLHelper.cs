using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shorter.Core.Helpers
{
    public static class GraphQLHelper
    {
        public async static Task<GraphQLResponse<CmsContents<T>>> ExecutePost<T>(CmsRequest request)
        {
            using (var client = new GraphQLHttpClient(request.Endpoint, new NewtonsoftJsonSerializer()))
            {
                client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {request.AccessTokenProvider.Get()}");

                var query = new GraphQLRequest
                {
                    Query = request.Query
                };

                return await client.SendQueryAsync<CmsContents<T>>(query);
            }
        }
   }    
}
