//-----------------------------------------------------------------------
// <copyright file="CountExtensions.cs" company="Lifeprojects.de">
//     Class: CountExtensions
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>02.12.2021</date>
//
// <summary>
// Klasse stellt Extension Methoden zum ermitteln der Anzahl Items 
// in einer generischen Collection zur Verfügung
// </summary>
//-----------------------------------------------------------------------

using System.Linq;

namespace System.Collections.Generic
{
    public static class CountExtensions
    {
        public static int TryCount<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                return 0;
            }

            switch (items)
            {
                case List<T> listCollection:
                    return listCollection.Count;
                case IList<T> ilistCollection:
                    return ilistCollection.Count;
                case ICollection<T> genCollection:
                    return genCollection.Count;
                case ICollection legacyCollection:
                    return legacyCollection.Count;
                case IReadOnlyCollection<T> roCollection:
                    return roCollection.Count;
                case IEnumerable<T> enumCollection:
                    return enumCollection.Count();
                default:
                    return 0;
            }
        }
    }
}
