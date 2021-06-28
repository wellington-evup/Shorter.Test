using System.Net.Http;

namespace Shorter.Core
{
    public class CmsRequest : IApiRequest
    {
        public string Endpoint { get; set; }
        public string Query { get; set; }
        public IAccessTokenProvider AccessTokenProvider { get; set; }
    }
}
