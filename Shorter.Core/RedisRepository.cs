using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shorter.Core
{
    public class RedisRepository : Repository<RedisRecord, RedisKey>
    {
        private bool disposedValue;
        private readonly ConnectionMultiplexer connection;

        public RedisRepository(ConnectionMultiplexer connection)
        {
            this.connection = connection;
        }

        public override void Delete(RedisKey key)
        {
            connection.GetDatabase().KeyDelete(key);
        }

        public override RedisRecord Get(RedisKey key)
        {
            return new RedisRecord(key, connection.GetDatabase().StringGet(key));
        }

        public override IEnumerable<RedisRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Insert(RedisRecord model)
        {
            connection.GetDatabase().StringSet(model.Key, model.Value);
        }

        public override void Update(RedisRecord model)
        {
            connection.GetDatabase().StringSet(model.Key, model.Value);
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
        // ~RedisRepository()
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
