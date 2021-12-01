#pragma warning disable CS1591

namespace InMemoryDB.Interface
{
    using System;

    public interface IRepository<TDomain> where TDomain : IDomainRoot
    {
        TDomain FindById(Guid id);

        void Add(TDomain domainObj);

        void Update(TDomain domainObj);

        void Delete(TDomain domainObj);
    }
}
