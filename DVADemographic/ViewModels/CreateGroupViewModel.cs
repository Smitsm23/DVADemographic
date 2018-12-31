using DVADemographic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.ViewModels
{
    public class CreateGroupViewModel
    {
        [Required]
        public Group Group { get; set; }
        
    }
}
