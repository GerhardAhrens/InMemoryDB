#pragma warning disable CS1591

namespace InMemoryDB.Interface
{
    using System;

    public interface IDomainRoot
    {
        Guid Id { get; set; }
    }
}
