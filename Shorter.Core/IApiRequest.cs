using System.Net.Http;

namespace Shorter.Core
{
    public interface IApiRequest
    {
        public string Endpoint { get; set; }
        public IAccessTokenProvider AccessTokenProvider { get; set; }
    }
}
