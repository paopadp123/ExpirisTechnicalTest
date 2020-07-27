
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ExpirisTechnicalTest.Models
{
    public class AbilitiesModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Habilidad")]
        public string Ability { get; set; }

        [Display(Name = "IsCheck")]
        public bool IsCheck { get; set; }

        //public List<AbilitiesModel> Abilities { get; set; }
    }
}