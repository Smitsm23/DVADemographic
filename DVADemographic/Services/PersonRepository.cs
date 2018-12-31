using DVADemographic.Data;
using DVADemographic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Services
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons;
        }

        public IEnumerable<Person> GetAllWithGroup()
        {
            return _context.Persons.Include(g => g.Group);
        }

        public IEnumerable<Person> FindWithGroup(Func<Person, bool> predicate)
        {
            return _context.Persons
                .Include(a => a.Group)
                .Where(predicate);
        }

    }
}
