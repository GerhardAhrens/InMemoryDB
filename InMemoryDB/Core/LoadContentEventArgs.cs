namespace InMemoryDB.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class LoadContentEventArgs<TDomain> : EventArgs
    {
        public XmlSerializer XmlSerializer { get; set; }

        public TextReader TextReader { get; set;}

        public List<SerializableKeyValuePair<Type, TDomain>> MemorySource { get; set; }
    }
}
