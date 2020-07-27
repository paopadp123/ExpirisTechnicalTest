using Dropdowns.Models.CandidatesSQL.Context;
using ExpirisTechnicalTest.Models.CandidatesSQL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dropdowns.Controllers
{
    public class CandidatesSQLController : Controller
    {
        private readonly CandidatesContext _context;

        public CandidatesSQLController(CandidatesContext context)
        {
            _context = context;
        }

       
        //[HttpPost]
        //public async Task(ActionResult<Candidates>) PostCandidateItem(Candidates item)
        //{
        //    _context.Candidate.Add(item);
        //    await _context.SaveChangesAsync();

        //    return CreateAction(nameof(GetCandidatesItemId), new { Id_Candidate = item.Id_Candidates }, item);
        //}
    }
}
