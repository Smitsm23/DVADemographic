using DVADemographic.Data;
using DVADemographic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Services
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Group> GetAllWithPersons()
        {
            return _context.Groups.Include(g => g.Persons);
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _context.Groups;
        }

        public Group GetWithPersons(int id)
        {
            return _context.Groups.Where(g => g.GroupId == id).Include(g => g.Persons).FirstOrDefault();
        }

        public override void Delete(Group entity)
        {
            var personsToRemove = _context.Persons.Where(p => p.Group == entity);

            base.Delete(entity);

            _context.Persons.RemoveRange(personsToRemove);

            Save();
        }
    }
}
