using MyParty.BL;
using MyParty.Infrastructure;
using MyParty.Models;
using MyParty.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParty.Controllers
{
    public class PartyController : Controller
    {
        IPartyService partyService;
        ILastViewedParties lastViewedParties;

        public PartyController(IPartyService r, ILastViewedParties lastViewedParties)
        {
            this.lastViewedParties = lastViewedParties;
            partyService = r;
            List<PartyViewModel> partyViews = partyService.ListOfCurrentParties().OrderBy(x => x.Date).Take(10).Select(x => new PartyViewModel { Id = x.Id, Title = x.Title, Location = x.Location, Date = x.Date }).ToList();
            ViewBag.ListParties = partyViews;
            ViewBag.NameListParties = "10 ближайших вечеринок:";
        }

        // GET: Party
        public ActionResult Index(int id)
        {
            
            lastViewedParties.AddParty(id);
            
            Party party = partyService.GetPartyByID(id);

            PartyParticipantsViewModel partyParticipantsViewModel = new PartyParticipantsViewModel();
            partyParticipantsViewModel.PartyID = id;
            partyParticipantsViewModel.PartyTitle = party.Title;
            partyParticipantsViewModel.PartyParticipants = partyService.ListAttendent().Where(x => x.PartyId == id).Select(x => new PartyParticipants { Id = x.Id, Name = x.Name, ArrivalDate = x.ArrivalDate }).ToList();

            return View(partyParticipantsViewModel);
        }

        public ActionResult Vote()
        {
            return View();
        }

        public ActionResult Save(ParticipantViewModel participantViewModel, HttpPostedFileBase file)
        {

            Participant participant = new Participant
            {
                Id = participantViewModel.Id,
                ArrivalDate = participantViewModel.ArrivalDate,
                Attend = participantViewModel.Attend,
                Name = participantViewModel.Name,
                Email = participantViewModel.Email,
                PartyId = participantViewModel.PartyId,
                Reason = participantViewModel.Reason,
            };

            if(file!=null)
            {
                string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParticipansPhoto", String.Concat(participant.Name, new FileInfo(file.FileName).Extension));
                file.SaveAs(_path);

            }

            partyService.Vote(participant);
            return RedirectToAction("Index", new {id = participantViewModel.PartyId});
        }

        public ActionResult GetImage(string userName)
        {
            string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParticipansPhoto", String.Concat(userName, ".jpg"));
            return File(_path, "image/jpg");
        }

        public ActionResult ListLastViewedParties()
        {
            List<int> listId = lastViewedParties.GetParties();

            List<PartyViewModel> partyViews = partyService.ListOfCurrentParties()
                .Where(x=> listId.Contains(x.Id))
                .Select(x => new PartyViewModel {
                    Id = x.Id,
                    Title = x.Title,
                    Location = x.Location,
                    Date = x.Date })
                .OrderByDescending(x => listId.FindIndex(y => x.Id == y))
                .ToList();

            ViewBag.ListParties = partyViews;
            ViewBag.NameListParties = "5 последних просмотренных вечеринок вечеринок:";

            return View("ListParties");
        }
    }
}