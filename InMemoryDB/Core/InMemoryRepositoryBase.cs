//-----------------------------------------------------------------------
// <copyright file="InMemoryRepositoryBase.cs" company="Lifeprojects.de">
//     Class: InMemoryRepositoryBase
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>30.12.2021</date>
//
// <summary>
// Klasse stellt eine Möglichkeit zum zum Simulieren und testen von Objekten
// beim bearbeiten über ein Repository zur Verfügung.
// </summary>
//-----------------------------------------------------------------------

#pragma warning disable CS1591

namespace InMemoryDB.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Xml.Serialization;

    using InMemoryDB.Interface;

    public abstract class InMemoryRepositoryBase<TDomain> : IRepository<TDomain> where TDomain : IEntityRoot
    {
        private List<SerializableKeyValuePair<Type,TDomain>> memorySource = null;

        protected InMemoryRepositoryBase()
        {
            this.memorySource = new List<SerializableKeyValuePair<Type,TDomain>>(); 
        }

        public List<SerializableKeyValuePair<Type, TDomain>> MemorySource { get { return this.memorySource; } }

        public int Count()
        {
            return this.memorySource.Count;
        }

        public virtual int CountByType()
        {
            int result = 0;
            if (memorySource != null)
            {
                Type typ = typeof(TDomain);
                result = this.memorySource.Count(w => w.Key == typ.Name);
            }

            return result;
        }

        public abstract IEnumerable<TDomain> FindAll();

        public abstract TDomain FindById(Guid id);

        public abstract IEnumerable<TDomain> FindBy(Expression<Func<TDomain, bool>> predicate);

        public virtual void Add(TDomain domainObj)
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                SerializableKeyValuePair<Type, TDomain> mc = new SerializableKeyValuePair<Type, TDomain>(typ, domainObj);
                this.memorySource.Add(mc);
            }
        }

        public virtual void Update(TDomain domainObj)
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

        public virtual void Delete(TDomain domainObj)
        {
            if (this.memorySource != null)
            {
                Type typ = typeof(TDomain);
                int index = this.memorySource.FindIndex(a => a.Key == typ.Name && a.Value.Id == domainObj.Id);
                this.memorySource.RemoveAt(index);
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
                    int index = this.memorySource.FindIndex(a => a.Key == typ.Name && a.Value.Id == byType[i].Id);
                    this.memorySource.RemoveAt(index);
                }
            }
        }

        public void DeleteAll()
        {
            if (this.memorySource != null)
            {
                this.memorySource.Clear();
            }
        }

        public virtual bool Exist(TDomain domainObj)
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

        public virtual bool ExistById(Guid id)
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

        public event EventHandler<LoadContentEventArgs<TDomain>> LoadContentEvent;

        protected virtual void OnLoadContent(LoadContentEventArgs<TDomain> e)
        {
            EventHandler<LoadContentEventArgs<TDomain>> handler = this.LoadContentEvent;
            if (handler != null)
            {
                handler(this, e);

                if (e.MemorySource != null)
                {
                    this.memorySource = e.MemorySource;
                }
            }
        }

        public void LoadContent(FileInfo fileInfo)
        {
            if (this.memorySource != null && this.memorySource.Count > 0)
            {
                this.memorySource.Clear();
            }

            XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(List<SerializableKeyValuePair<Type, TDomain>>) })[0];
            using (TextReader rdr = new StreamReader(fileInfo.FullName))
            {
                LoadContentEventArgs<TDomain> e = new LoadContentEventArgs<TDomain>();
                e.XmlSerializer = serializer;
                e.TextReader = rdr;
                this.OnLoadContent(e);
                rdr.Close();
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
