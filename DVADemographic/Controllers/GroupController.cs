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
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        
        public IActionResult Update(int id)
        {
            var group = _groupRepository.GetById(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Group group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }

            _groupRepository.Update(group);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ViewResult Create()
        {
            return View(new CreateGroupViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGroupViewModel groupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(groupViewModel);
            }

            _groupRepository.Create(groupViewModel.Group);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Delete(int id)
        {
            var person = _groupRepository.GetById(id);

            _groupRepository.Delete(person);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
