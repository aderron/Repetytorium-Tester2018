using System;

namespace TestWebsite.Models
{
    public class Person
    {
        public Person(Pesel pesel, string firstName, string lastName, string birthPlace, string Issuer)
        {
            this.Pesel = pesel;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthPlace = birthPlace;
            this.Issuer = Issuer;
        }

        public Pesel Pesel { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string BirthPlace { get; }
        
        public string Issuer { get; }

        public DateTime BirthDate => this.Pesel.BirthDate;

        internal bool IsValid()
        {
            return true;
        }
    }
}