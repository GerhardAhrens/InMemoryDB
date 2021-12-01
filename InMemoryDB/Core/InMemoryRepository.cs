#pragma warning disable CS1591

namespace InMemoryDB.Core
{
    using InMemoryDB.Interface;

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public class InMemoryRepository<TDomain> : IRepository<TDomain> where TDomain : IDomainRoot
    {
        private List<SerializableKeyValuePair<Type,TDomain>> memorySource = null;

        public InMemoryRepository()
        {
            this.memorySource = new List<SerializableKeyValuePair<Type,TDomain>>(); 
        }

        public int Count()
        {
            return this.memorySource.Count;
        }

        public int CountByType()
        {
            int result = 0;
            if (memorySource != null)
            {
                Type typ = typeof(TDomain);
                result = this.memorySource.Count(w => w.Key == typ.Name);
            }

            return result;
        }

        public List<TDomain> FindAll()
        {
            List<TDomain> result = null;
            if (this.memorySource != null)
            {
                result = this.memorySource.Select(s => s.Value).ToList<TDomain>();
            }

            return result;
        }

        public TDomain FindById(Guid id)
        {
            TDomain result = default(TDomain);

            if (this.memorySource != null)
            {
                if (this.memorySource.Any(a => a.Value.Id == id))
                {
                    result = this.memorySource.Where(w => w.Value.Id == id).FirstOrDefault().Value;
                }
            }

            return result;
        }

        public void Add(TDomain domainObj)
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                SerializableKeyValuePair<Type, TDomain> mc = new SerializableKeyValuePair<Type, TDomain>(typ, domainObj);
                this.memorySource.Add(mc);
            }
        }

        public void Update(TDomain domainObj)
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                TDomain oldDomain = (TDomain)this.memorySource.Where(w => w.Value.Id == domainObj.Id).FirstOrDefault().Value;
                var index = this.memorySource.FindIndex(w => w.Value.Id == oldDomain.Id);
                SerializableKeyValuePair<Type, TDomain> mc = new SerializableKeyValuePair<Type, TDomain>(typ, domainObj);
                this.memorySource[index] = mc;
            }
        }

        public void Delete(TDomain domainObj)
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                SerializableKeyValuePair<Type, TDomain> mc = new SerializableKeyValuePair<Type, TDomain>(typ, domainObj);
                this.memorySource.Remove(mc);
            }
        }

        public void DeleteAllByType()
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                List<TDomain> byType = this.memorySource.Where(c => c.Key == typ.Name).Select(s => s.Value).ToList();
                for (int i = 0; i < byType.Count; i++)
                {
                    TDomain oldDomain = this.memorySource.Where(w => w.Value.Id == byType[i].Id).FirstOrDefault().Value;
                    SerializableKeyValuePair<Type, TDomain> mc = new SerializableKeyValuePair<Type, TDomain>(typ, oldDomain);
                    this.memorySource.Remove(mc);
                }
            }
        }

        public void DeleteAll()
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                this.memorySource.Clear();
            }
        }

        public bool Exist(TDomain domainObj)
        {
            bool result = false;

            if (this.memorySource != null)
            {
                if (this.memorySource.Any(a => a.Value.Id == domainObj.Id))
                {
                    result = true;
                }
            }

            return result;
        }

        public bool ExistById(Guid id)
        {
            bool result = false;

            if (this.memorySource != null)
            {
                if (this.memorySource.Any(a => a.Value.Id == id))
                {
                    result = true;
                }
            }

            return result;
        }

        public void SaveContent(string filename)
        {
            if (this.memorySource != null && this.memorySource.Count > 0)
            {
                XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(List<SerializableKeyValuePair<Type, TDomain>>) })[0];
                using (TextWriter textWriter = new StreamWriter(filename))
                {
                    serializer.Serialize(textWriter, this.memorySource);
                    textWriter.Close();
                }
            }
        }

        public void LoadContent(string filename)
        {
            if (this.memorySource != null && this.memorySource.Count > 0)
            {
                this.memorySource.Clear();
            }

            XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(List<SerializableKeyValuePair<Type, TDomain>>) })[0];
            using (TextReader rdr = new StreamReader(filename))
            {
                this.memorySource = (List<SerializableKeyValuePair<Type, TDomain>>)serializer.Deserialize(rdr);
                rdr.Close();
            }

        }
    }
}
