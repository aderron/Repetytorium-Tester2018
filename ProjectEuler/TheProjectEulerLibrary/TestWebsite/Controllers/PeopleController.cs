using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebsite.Controllers
{
    [RoutePrefix("people")]
    public class PeopleController : ApiController
    {
        private static List<Person> People = new List<Person>()
        {
            new Person("213123213", "Piotr", age:23),
            new Person("213123214", "Paulina", age:21),
            new Person("213123215", "Ania", age:21),
            new Person("213123216", "Xavery", age:55)
        };

        [HttpGet]
        [Route("GetList")]
        public IEnumerable<string> GetList()
        {
            return People.Select(p => p.Pesel);
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Person person)
        {
            if (person == null)
            {
                return this.BadRequest();
            }

            if (People.Any(p => p.Pesel == person.Pesel))
            {
                return this.BadRequest($"Person with pesel {person.Pesel} already exists");
            }

            if (person.IsValid())
            {
                People.Add(person);
                return this.Ok();
            }

            return this.BadRequest();

        }

        [HttpGet]
        [Route("GetByPesel/{pesel}")]
        public Person GetByPesel(string pesel)
        {
            return People.SingleOrDefault(p => p.Pesel == pesel);
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(string pesel)
        {
            if (string.IsNullOrWhiteSpace(pesel))
            {
                return this.BadRequest();
            }

            var personToDelete = People.SingleOrDefault(p => p.Pesel == pesel);
            if (personToDelete != null)
            {
                People.Remove(personToDelete);
                return this.Ok();
            }

            return this.NotFound();
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(Person person)
        {
            if (person == null)
            {
                return this.BadRequest();
            }

            var personToUpdate = People.SingleOrDefault(p => p.Pesel == person.Pesel);
            if (personToUpdate != null)
            {
                People.Remove(personToUpdate);
                People.Add(person);
                return this.Ok();
            }

            return this.NotFound();
        }
    }

    public class Person
    {
        public Person(string pesel, string name, int age)
        {
            this.Name = name;
            this.Age = age;
            Pesel = pesel;
        }

        public string Pesel { get; }

        public string Name { get; }

        public int Age { get; }

        internal bool IsValid()
        {
            return this.Age > 0 && !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Pesel);
        }
    }

    public class Pesel
    {
        public string Value;

        public Pesel(string value)
        {
            if (value.Length != 11)
            {
                throw new ApplicationException($"Invalid pesel {value}");
            }

            this.Value = value;
        }
    }
}
