using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }
        public int PersonCount { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
