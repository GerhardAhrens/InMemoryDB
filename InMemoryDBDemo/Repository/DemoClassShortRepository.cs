namespace InMemoryDBDemo.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    using InMemoryDB.Core;

    internal class DemoClassShortRepository : InMemoryRepositoryBase<DemoClassShort>
    {
        public override IEnumerable<DemoClassShort> FindAll()
        {
            List<DemoClassShort> result = null;
            if (this.MemorySource != null)
            {
                result = this.MemorySource.Select(s => s.Value).ToList<DemoClassShort>();
            }

            return result;
        }

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

        public override IEnumerable<DemoClassShort> FindBy(Expression<Func<DemoClassShort, bool>> predicate)
        {
            IQueryable<DemoClassShort> src = this.MemorySource.Select(s => s.Value).AsQueryable();
            return src.Where(predicate);
        }
    }
}
