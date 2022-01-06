//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Lifeprojects.de">
//     Class: Person
//     Copyright © Lifeprojects.de 2022
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>06.01.2022 10:32:28</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace InMemoryDBDemo
{
    using System;

    using InMemoryDB.Interface;

    public class Person : IEntityRoot
    {
        public Person()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person(string firstName, string lastName, PersonType personTyp)
        {
            this.Id = Guid.NewGuid();
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.PersonType = personTyp;
        }

        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public PersonType PersonType { get; set; }
    }

    public enum PersonType : int
    {
        None = 0,
        User = 1,
        Administrator = 2
    }
}
