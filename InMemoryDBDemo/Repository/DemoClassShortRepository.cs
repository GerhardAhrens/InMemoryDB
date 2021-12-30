namespace InMemoryDBDemo.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using InMemoryDB.Core;

    internal class DemoClassShortRepository : InMemoryRepositoryBase<DemoClassShort>
    {
        public override DemoClassShort FindById(Guid id)
        {
            DemoClassShort result = default(DemoClassShort);

            if (this.MemorySource != null)
            {
                if (this.MemorySource.Any(a => a.Value.Id == id))
                {
                    result = this.MemorySource.Where(w => w.Value.Id == id).FirstOrDefault().Value;
                }
            }

            return result;
        }
    }
}
