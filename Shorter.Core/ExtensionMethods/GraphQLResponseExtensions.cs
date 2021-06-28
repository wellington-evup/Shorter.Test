using GraphQL;
using System.Collections.Generic;
using System.Linq;

namespace Shorter.Core.ExtensionMethods
{
    public static class GraphQLResponseExtensions
    {
        public static IEnumerable<T> ConvertResult<T>(this GraphQLResponse<CmsContents<T>> response)
        {
            return response.Data.queryMarketingDigitalVinculoContents.Select(x => x.flatData);
        }
    }
}
