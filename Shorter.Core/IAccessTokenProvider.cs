namespace Shorter.Core
{
    public interface IAccessTokenProvider
    {
        AccessToken Get();
    }

    public abstract class AccessTokenProvider : IAccessTokenProvider
    {
        public abstract AccessToken Get();
    }
}