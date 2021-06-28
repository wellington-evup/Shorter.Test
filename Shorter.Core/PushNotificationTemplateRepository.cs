using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shorter.Core
{
    public class PushNotificationTemplateRepository : SqlRepository<PushNotificationTemplate>
    {
        private bool disposedValue;
        private readonly IDbConnection connection;

        public PushNotificationTemplateRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public override void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public override PushNotificationTemplate Get(long id)
        {
            return connection.QueryFirstOrDefault<PushNotificationTemplate>("select * from sch1.PushNotificationTemplate where Id = @id", new { id });
        }

        public override IEnumerable<PushNotificationTemplate> GetAll()
        {
            return connection.Query<PushNotificationTemplate>("select * from sch1.PushNotificationTemplate");
        }

        public override void Insert(PushNotificationTemplate model)
        {
            throw new NotImplementedException();
        }

        public override void Update(PushNotificationTemplate model)
        {
            throw new NotImplementedException();
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
        // ~PushNotificationTemplateRepository()
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
