using ExpirisTechnicalTest.Models.SearchCandidate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpirisTechnicalTest.Models
{
    public class CandidatesModel
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }

        public List<CandidatesModel> ArrayCandidates { get; set; }
    }
}