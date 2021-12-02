//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Lifeprojects.de">
//     Class: IRepository
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
    using System.Collections.Generic;

    public interface IRepository<TDomain> where TDomain : IEntityRoot
    {
        int Count();

        TDomain FindById(Guid id);

        IEnumerable<TDomain> FindAll();

        void Add(TDomain domainObj);

        void Update(TDomain domainObj);

        void Delete(TDomain domainObj);

        void DeleteAll();

        bool Exist(TDomain domainObj);

        bool ExistById(Guid id);

        void SaveContent(string filename);

        void LoadContent(string filename);
    }
}
