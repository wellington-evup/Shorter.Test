using Shorter.Core.ExtensionMethods;
using Shorter.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Shorter.Core
{
    public class MarketingDigitalRepository : CmsReadonlyRepository<MarketingDigital>
    {
        private bool disposedValue;
        private readonly IAccessTokenProvider accessTokenProvider;

        public MarketingDigitalRepository(IAccessTokenProvider accessTokenProvider)
        {
            this.accessTokenProvider = accessTokenProvider;
        }

        public override MarketingDigital Get(string id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<MarketingDigital> GetAll()
        {
            var cmsRequest = new CmsRequest()
            {
                Endpoint = @"https://cms-dev.evup.com.br/api/content/shared/graphql",
                AccessTokenProvider = accessTokenProvider,
                Query = @"{
                                  queryMarketingDigitalVinculoContents{
                                    flatData{
                                      path,
                                      redirectTo
                                    }
                                  }
                                }"
            };
            return GraphQLHelper.ExecutePost<MarketingDigital>(cmsRequest).Result.ConvertResult();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MarketingDigitalRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public override void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
