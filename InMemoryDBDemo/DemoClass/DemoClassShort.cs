namespace InMemoryDBDemo
{
    using InMemoryDB.Interface;

    using System;
    using System.Xml.Serialization;


    /// <summary>
    /// Eine kleine Demo Klasse
    /// </summary>
    [Serializable]
    public class DemoClassShort : IDomainRoot
    {
        /// <summary>
        /// Konstruktor ohne Parameter
        /// </summary>
        public DemoClassShort()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public DemoClassShort(string param)
        {
        }

        /// <summary>
        /// Object Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Klasseninhalt als String zurückgeben
        /// </summary>
        /// <returns>Inhalt als String</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
