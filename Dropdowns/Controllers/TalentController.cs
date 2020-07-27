using ExpirisTechnicalTest.Models;
using ExpirisTechnicalTest.Models.SearchCandidate;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using System.Web.UI;

namespace ExpirisTechnicalTest.Controllers
{
    public class TalentController : Controller
    {
        public ActionResult Index()
        {
            var technologies = GetTechnologies();
            var model = new DropdownlistTecnologyModel();
            model.Technologies = GetSelectListItems(technologies);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DropdownlistTecnologyModel model)
        {
            var technologies = GetTechnologies();
            model.Technologies = GetSelectListItems(technologies);

            if (ModelState.IsValid)
            {
                Session["DropdownlistTecnologyModel"] = model;
                return RedirectToAction("Abilities");
            }

            return View("Index", model);
        }

        private IEnumerable<string> GetTechnologies()
        {
            return new List<string>
            {
                "Microsoft-NET",
                "Orecle-JAVA",
            };
        }

        [HttpGet]
        public ActionResult Abilities()
        {
            var model = Session["DropdownlistTecnologyModel"] as DropdownlistTecnologyModel;        
            var modelAbilities = GetListAbilities(model.Technology);

            return View(modelAbilities);
        }

        [HttpPost]
        public ActionResult Abilities(List<AbilitiesModel> model)
        {
            if (ModelState.IsValid)
            {
                Session["AbilitiesModel"] = model;
                return RedirectToAction("CandidateSelected");
            }
            return View("Abilities");
        }

        public ActionResult CandidateSelected()
        {
            var ListSelected = Session["AbilitiesModel"] as List<AbilitiesModel>;
            int pair = 0;
            var model = new CandidatesModel();
            string jsonCandidates = (GetSearchTalent("http://jsonplaceholder.typicode.com/users")).Content;
            var candidates = JsonConvert.DeserializeObject<List<CandidatesModel>>(jsonCandidates);

            var a = ListSelected[0].IsCheck;
            if (ListSelected[0].IsCheck || ListSelected[2].IsCheck)
            {
                pair = 1;
            }
            var listCandidates = GetListCandidatesSelected(candidates, pair);
            model.ArrayCandidates = listCandidates;
            return View(model);
        }

        [HttpPost]
        public ActionResult CandidateSelected(List<AbilitiesModel> model)
        {
            if (ModelState.IsValid)
            {
                Session["CandidateSelected"] = model;
                return RedirectToAction("ScheduleCandidates");
            }
            return View("CandidateSelected");
        }

        public ActionResult ScheduleCandidates()
        {
            int selected = 1;
            int pair = 0;
            var model = new CandidatesModel();
            string jsonCandidates = (GetSearchTalent("http://jsonplaceholder.typicode.com/users")).Content;
            var candidates = JsonConvert.DeserializeObject<List<CandidatesModel>>(jsonCandidates);

            if (selected == 2 || selected == 4)
            {
                pair = 1;
            }
            var listCandidates = GetListCandidatesSelected(candidates, pair);
            model.ArrayCandidates = listCandidates;
            return View(model);
        }

        private List<CandidatesModel> GetListCandidatesSelected(List<CandidatesModel> ArrayCandidatesModel, int pair)
        {
            List<CandidatesModel> slectedCandidates = new List<CandidatesModel>();

            foreach (var candidate in ArrayCandidatesModel)
            {
                if (candidate.id % 2 == pair)
                {
                    slectedCandidates.Add(candidate);
                }
            }
            return slectedCandidates;
        }

        private List<AbilitiesModel> GetListAbilities(string skill)
        {
            List<AbilitiesModel> abilities = new List<AbilitiesModel>();
            if (skill == "Microsoft-NET")
            {
                abilities.Add(new AbilitiesModel() { Id = 1, Ability = "Asp.Net", IsCheck = false});
                abilities.Add(new AbilitiesModel() { Id = 2, Ability = "MVVM", IsCheck = false });
                abilities.Add(new AbilitiesModel() { Id = 3, Ability = "Ado.Net ", IsCheck = false });
                abilities.Add(new AbilitiesModel() { Id = 4, Ability = "Entity FrameWorkt", IsCheck = false });
                abilities.Add(new AbilitiesModel() { Id = 5, Ability = "LinQ ", IsCheck = false });
                return abilities;
            }

            abilities.Add(new AbilitiesModel() { Id = 1, Ability = "Java Server Pages", IsCheck = false });
            abilities.Add(new AbilitiesModel() { Id = 2, Ability = "Java Server Faces", IsCheck = false });
            abilities.Add(new AbilitiesModel() { Id = 3, Ability = "Enterprise Java Beans", IsCheck = false });
            abilities.Add(new AbilitiesModel() { Id = 4, Ability = "Java Persistence Api", IsCheck = false });
            abilities.Add(new AbilitiesModel() { Id = 5, Ability = "Java Messaging Services", IsCheck = false });
            return abilities;
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }

        [HttpPost]
        public IRestResponse GetSearchTalent(string uri)
        {
            IRestResponse response;
            try
            {
                var client = new RestClient(uri);
                var request = new RestRequest(Method.GET);
                response = client.Execute(request);
            }
            catch (System.Exception e)
            {
                return (IRestResponse)e;
            }
            return response;
        }

    }
}
