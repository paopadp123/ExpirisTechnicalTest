using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpirisTechnicalTest.Models
{
    public class DropDownListTechnology
    {
        [Required]
        [Display(Name = "Technology")]
        public string Technology { get; set; }

        // This property will hold a state, selected by user
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> States { get; set; }
    }
}
