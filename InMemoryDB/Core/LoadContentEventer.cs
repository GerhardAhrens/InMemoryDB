//-----------------------------------------------------------------------
// <copyright file="LoadContentEventer.cs" company="Lifeprojects.de">
//     Class: LoadContentEventer
//     Copyright © Lifeprojects.de 2022
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>06.01.2022 10:13:47</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace InMemoryDB.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    public class LoadContentEventer<TDomain>
    {
        public event EventHandler<LoadContentEventArgs<TDomain>> LoadContentEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadContentEventer"/> class.
        /// </summary>
        public LoadContentEventer(List<SerializableKeyValuePair<Type, TDomain>> memorySource)
        {
            this.ValueArgs = memorySource;
        }

        public List<SerializableKeyValuePair<Type, TDomain>> ValueArgs { get; private set; }

        public void OnLoadContent(LoadContentEventArgs<TDomain> e)
        {
            EventHandler<LoadContentEventArgs<TDomain>> handler = this.LoadContentEvent;
            if (handler != null)
            {
                handler(this, e);

                if (e.MemorySource != null)
                {
                    this.ValueArgs = e.MemorySource;
                }
            }
        }
    }
}
