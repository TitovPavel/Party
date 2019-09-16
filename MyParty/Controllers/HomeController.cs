using MyParty.BL;
using MyParty.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParty.Controllers
{
    public class HomeController : Controller
    {

        IPartyService partyService;

        public HomeController(IPartyService r)
        {
            partyService = r;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<PartyViewModel> partyViews = partyService.ListOfCurrentParties().Select(_ => new PartyViewModel { Id = _.Id, Title = _.Title }).ToList();
            return View(partyViews);
        }
    }
}