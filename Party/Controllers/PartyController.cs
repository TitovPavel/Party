using Party.BL;
using Party.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Party.Controllers
{
    public class PartyController : Controller
    {
        IParticipantsService repo;
        public PartyController(IParticipantsService r)
        {
            repo = r;
        }

        // GET: Party
        public ActionResult Index()
        {
            return View(repo.ListAttendent());
        }

        public ActionResult Vote()
        {
            return View();
        }

        public ActionResult Save(Participant participant)
        {
            repo.Vote(participant.Name, participant.Attend, participant.Reason);
            return RedirectToAction("Index");
        }
    }
}