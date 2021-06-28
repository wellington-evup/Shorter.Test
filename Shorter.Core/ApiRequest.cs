using System.Net.Http;

namespace Shorter.Core
{
    public class ApiRequest
    {
        public string Endpoint { get; set; }
        public HttpContent RequestObject { get; set; }
        public IAccessTokenProvider AccessTokenProvider { get; set; }
    }
}
