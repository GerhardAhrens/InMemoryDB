//-----------------------------------------------------------------------
// <copyright file="IEntityRoot.cs" company="Lifeprojects.de">
//     Class: IEntityRoot
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>01.12.2021</date>
//
// <summary>
// Klasse stellt ein Interface IEntityRoot zur Verwendung in
// Entitäten Klassen zur Verfügung
// </summary>
//-----------------------------------------------------------------------

#pragma warning disable CS1591

namespace InMemoryDB.Interface
{
    using System;

    public interface IEntityRoot
    {
        Guid Id { get; set; }
    }
}
