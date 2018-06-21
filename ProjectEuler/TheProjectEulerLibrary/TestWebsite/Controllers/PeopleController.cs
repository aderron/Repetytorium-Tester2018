using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web.Http;
using TestWebsite.Models;
using TestWebsite.Repository;

namespace TestWebsite.Controllers
{
    // https://pesel.cstudios.pl/O-generatorze/Generator-On-Line
    // http://imiona.nazwiska-polskie.pl/zenskie

    [RoutePrefix("People")]
    public class PeopleController : ApiController
    {
        private static readonly IRepository<Pesel, Person> repository;

        static PeopleController()
        {
            repository = new PeselRepository();
            var people = new List<Person>
            {
                new Person(new Pesel("88031469364"), "Jan", "Kowalski", "Warszawa", "Prezydent Miasta Warszawa"),
                new Person(new Pesel("88031443355"), "Krzysztof", "Nowak", "Gdańsk", "Prezydent Miasta Gdańska"),
                new Person(new Pesel("69120677132"), "Stanisław", "Nejgebauer", "Cęstochowa", "Prezydent Miasta Cęstochowa"),
                new Person(new Pesel("98071652583"), "Andrzej", "Chołast", "Wrocław", "Prezydent Miasta Wrocław"),
                new Person(new Pesel("84110852656"), "Józef", "Szafoni", "Katowice", "Prezydent Miasta Katowice"),
                new Person(new Pesel("45100954549"), "Maria", "Szocik", "Poznań", "Prezydent Miasta Poznań"),
                new Person(new Pesel("61071972713"), "Krystyna", "Spodymek", "Bełchatów", "Prezydent Miasta Bełchatów"),
                new Person(new Pesel("70030828136"), "Anna", "Korpecki", "Szczecin", "Prezydent Miasta Szczecin"),
                new Person(new Pesel("70061089537"), "Barbara", "Zgłobica", "Białystok", "Prezydent Miasta Białystok"),
                new Person(new Pesel("55050253137"), "Teresa", "Piotrowski", "Chorzów", "Prezydent Miasta Chorzów")
            };

            foreach (var person in people)
            {
                repository.Add(person);
            }
        }

        [HttpGet]
        [Route("List")]
        public IEnumerable<Pesel> List()
        {
            return repository.List();
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            try
            {
                repository.Add(person);
                return Created($"/api/People/Read/{person.Pesel}", person);
            }
            catch (DuplicateKeyException e)
            {
                return Conflict();
            }
        }

        [HttpGet]
        [Route("Read/{pesel}")]
        public IHttpActionResult Read(string pesel)
        {
            if (pesel == null)
            {
                return BadRequest();
            }

            try
            {
                var id = new Pesel(pesel); 
                return Ok(repository.Get(id));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{pesel}")]
        public IHttpActionResult Delete(string pesel)
        {
            if (pesel == null)
            {
                return BadRequest();
            }

            try
            {
                var id = new Pesel(pesel);
                repository.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            catch (ApplicationException e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            try
            {
                repository.Update(person);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }
    }
}