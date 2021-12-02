//-----------------------------------------------------------------------
// <copyright file="SerializableKeyValuePair.cs" company="Lifeprojects.de">
//     Class: SerializableKeyValuePair
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>01.12.2021</date>
//
// <summary>
// Klasse stellt eine Key-Value Paar das auch serielisiert werden kann zur
// Verfügung. Die Klasse kann z.B. in einem List<SerializableKeyValuePair>
// eingesetzt werden
// </summary>
//-----------------------------------------------------------------------

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
