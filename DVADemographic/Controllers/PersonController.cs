using DVADemographic.Models;
using DVADemographic.Services;
using DVADemographic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IGroupRepository _groupRepository;

        public PersonController(IPersonRepository personRepository, IGroupRepository groupRepository)
        {
            _personRepository = personRepository;
            _groupRepository = groupRepository;
        }

        [Route("Person")]
        public IActionResult List(int? groupId)
        {
            var person = _personRepository.GetAllWithGroup().ToList();

            IEnumerable<Person> persons;

            ViewBag.GroupId = groupId;

            if (groupId == null)
            {
                persons = _personRepository.GetAllWithGroup();

                return CheckPersonCount(persons);
            }
            else
            {
                var group = _groupRepository.GetWithPersons((int)groupId);

                if (group.Persons == null || group.Persons.Count == 0)
                {
                    return View("EmptyPerson", group);
                }

                persons = _personRepository.FindWithGroup(g => g.Group.GroupId == groupId);

                return CheckPersonCount(persons);
            }
        }

        private IActionResult CheckPersonCount(IEnumerable<Person> persons)
        {
            if (persons == null || persons.ToList().Count == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(persons);
            }
        }

        

        public IActionResult Detail(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Update(int id)
        {
            Person person = _personRepository.FindWithGroup(a => a.PersonId == id).FirstOrDefault();

            if (person == null)
            {
                return NotFound();
            }

            var personVM = new PersonEditViewModel
            {
                Person = person,
                Groups = _groupRepository.GetAll()
            };

            return View(personVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PersonEditViewModel personVM)
        {
            if (!ModelState.IsValid)
            {
                personVM.Groups = _groupRepository.GetAll();
                return View(personVM);
            }
            _personRepository.Update(personVM.Person);

            return RedirectToAction("List");
        }

        public IActionResult Create(int? groupId)
        {
            Person person = new Person();

            if (groupId != null)
            {
                person.GroupId = (int)groupId;
            }

            var vm = new PersonEditViewModel
            {
                Groups = _groupRepository.GetAll(),
                Person = person
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonEditViewModel personVM)
        {
            if (!ModelState.IsValid)
            {
                personVM.Groups = _groupRepository.GetAll();
                return View(personVM);
            }

            _personRepository.Create(personVM.Person);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id, int? groupId)
        {
            var person = _personRepository.GetById(id);

            _personRepository.Delete(person);

            return RedirectToAction("List", new { groupId });
        }


    }
}
