using DVADemographic.Data;
using DVADemographic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.ViewModels
{
    public class PersonEditViewModel
    {
        
        public Person Person { get; set; }
        

        public IEnumerable<Group> Groups { get; set; }

    }
}
