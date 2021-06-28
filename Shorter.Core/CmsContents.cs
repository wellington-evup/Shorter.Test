namespace Shorter.Core
{
    public class CmsContents<T>
    {
        public QueryContents<T>[] queryMarketingDigitalVinculoContents { get; set; }
    }

    public class QueryContents<T>
    {
        public T flatData { get; set; }
    }
}
