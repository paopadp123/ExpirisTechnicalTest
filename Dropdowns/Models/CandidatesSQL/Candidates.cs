using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpirisTechnicalTest.Models.CandidatesSQL
{
    public class Candidates
    {
        [Key]
        public int Id_Candidates { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string format { get; set; }

    }
}