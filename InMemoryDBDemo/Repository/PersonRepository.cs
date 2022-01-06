namespace InMemoryDBDemo.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using InMemoryDB.Core;

    internal class PersonRepository : InMemoryRepositoryBase<Person>
    {
        public override IEnumerable<Person> FindAll()
        {
            List<Person> result = null;
            if (this.MemorySource != null)
            {
                result = this.MemorySource.Select(s => s.Value).ToList<Person>();
            }

            return result;
        }

        public override Person FindById(Guid id)
        {
            Person result = default(Person);

            if (this.MemorySource != null)
            {
                if (this.MemorySource.Any(a => a.Value.Id == id))
                {
                    result = this.MemorySource.Where(w => w.Value.Id == id).FirstOrDefault().Value;
                }
            }

            return result;
        }

        public override IEnumerable<Person> FindBy(Expression<Func<Person, bool>> predicate)
        {
            IQueryable<Person> src = this.MemorySource.Select(s => s.Value).AsQueryable();
            return src.Where(predicate);
        }
    }
}
