using DVADemographic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Services
{
    public interface IPersonRepository : IRepository<Person>
    {
        //IEnumerable<Person> GetAllPersons();
        IEnumerable<Person> GetAllWithGroup();
        IEnumerable<Person> FindWithGroup(Func<Person, bool> predicate);
    }
}
