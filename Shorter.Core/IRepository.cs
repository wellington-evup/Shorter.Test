using System;
using System.Collections.Generic;

namespace Shorter.Core
{
    public interface ISqlRepository<X> : IRepository<X, long>, ISqlReadonlyRepository<X>
    {
    }

    public interface IRepository<X, Y> : IReadonlyRepository<X, Y>
    {
        void Insert(X model);
        void Update(X model);
        void Delete(Y id);
    }

    public interface ICmsReadonlyRepository<X> : IReadonlyRepository<X, string>
    {
    }

    public interface ISqlReadonlyRepository<X> : IReadonlyRepository<X, long>
    {
    }

    public interface IReadonlyRepository<X, Y> : IDisposable
    {
        X Get(Y id);
        IEnumerable<X> GetAll();
    }

    public abstract class CmsReadonlyRepository<X> : ReadonlyRepository<X, string>, ICmsReadonlyRepository<X>
    {
    }

    public abstract class SqlRepository<X> : Repository<X, long>, ISqlRepository<X>
    {
    }

    public abstract class Repository<X, Y> : ReadonlyRepository<X, Y>, IRepository<X, Y>
    {
        public abstract void Insert(X model);
        public abstract void Update(X model);
        public abstract void Delete(Y id);
    }

    public abstract class SqlReadonlyRepository<X> : ReadonlyRepository<X, long>, ISqlReadonlyRepository<X>
    {
    }

    public abstract class ReadonlyRepository<X, Y> : IReadonlyRepository<X, Y>
    {
        public abstract X Get(Y id);
        public abstract IEnumerable<X> GetAll();
        public abstract void Dispose();
    }
}
