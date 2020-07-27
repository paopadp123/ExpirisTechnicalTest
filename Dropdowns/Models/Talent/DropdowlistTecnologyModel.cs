using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ExpirisTechnicalTest.Models
{
    public class DropdownlistTecnologyModel
    {
        [Required]
        [Display(Name = "Technology")]
        public string Technology { get; set; }

        public IEnumerable<SelectListItem> Technologies { get; set; }
    }
}