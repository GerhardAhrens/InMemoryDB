namespace InMemoryDBDemo
{
    using InMemoryDB.Interface;

    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;


    /// <summary>
    /// Eine kleine Demo Klasse
    /// </summary>
    [DebuggerDisplay("Id={this.Id}; ClassName={this.ClassName}")]
    [Serializable]
    public class DemoClassShort : IEntityRoot
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
