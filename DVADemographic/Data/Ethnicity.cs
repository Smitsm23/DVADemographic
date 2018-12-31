using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVADemographic.Data
{
    public class Ethnicity
    {
        public static IEnumerable<SelectListItem> GetEthnicList()
        {
            IList<SelectListItem> states = new List<SelectListItem>
            {
                new SelectListItem() { Value="Select", Text="Select"},
                new SelectListItem() { Value="White", Text="White"},
                new SelectListItem() { Value="Mixed", Text="Mixed or Multiple"},
                new SelectListItem() { Value="Asian", Text="Asian"},
                new SelectListItem() { Value="Black", Text="Black"},
                new SelectListItem() { Value="Other", Text="Other"},
                
            };
            return states;
        }
    }
}
