using System;
using System.Collections.Generic;
using System.Data.Linq;
using TestWebsite.Models;

namespace TestWebsite.Repository
{
    public interface IRepository<TId, TType>
    {
        IEnumerable<TId> List();
        void Add(TType element);
        TType Get(TId id);
        void Update(TType element);
        void Delete(TId id);
    }

    public class PeselRepository : IRepository<Pesel, Person>
    {
        private readonly IDictionary<Pesel, Person> People = new Dictionary<Pesel, Person>();

        public IEnumerable<Pesel> List()
        {
            return this.People.Keys;
        }

        public void Add(Person element)
        {
            if (this.People.ContainsKey(element.Pesel))
            {
                throw new DuplicateKeyException($"Person {element.Pesel} already exists");
            }

            this.People.Add(element.Pesel, element);
        }

        public Person Get(Pesel id)
        {
            if (this.People.ContainsKey(id))
            {
                return this.People[id];
            }

            throw new KeyNotFoundException($"Person {id} not found");
        }

        public void Update(Person element)
        {
            if (this.People.ContainsKey(element.Pesel))
            {
                this.People.Remove(element.Pesel);
                this.People.Add(element.Pesel, element);
            }
        }

        public void Delete(Pesel id)
        {
            if (this.People.ContainsKey(id))
            {
                this.People.Remove(id);
            }

            throw new KeyNotFoundException($"Person {id} not found");
        }
    }
}