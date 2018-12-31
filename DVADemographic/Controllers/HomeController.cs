using DVADemographic.Services;
using DVADemographic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IGroupRepository _groupRepository;

        public HomeController(IPersonRepository personRepository, IGroupRepository groupRepository)
        {
            _personRepository = personRepository;
            _groupRepository = groupRepository;
        }

        public IActionResult Index()
        {
            
            var groups = _groupRepository.GetAllWithPersons();

            return View(groups);
        }

    }
}
