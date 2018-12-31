using DVADemographic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Services
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Group> GetAllWithPersons();
        Group GetWithPersons(int id);
        IEnumerable<Group> GetAllGroups();
    }
}
