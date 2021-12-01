#pragma warning disable CS1591

namespace InMemoryDB.Core
{
    using System;

    [Serializable]
    public sealed class SerializableKeyValuePair<Type, TDomain>
    {

        public SerializableKeyValuePair()
        {
        }

        public SerializableKeyValuePair(Type key, TDomain value)
        {
            this.Key = typeof(TDomain).Name;
            this.Value = value;
        }

        //[XmlIgnore]
        public string Key { get; set; }

        public TDomain Value { get; set; }

    }
}
