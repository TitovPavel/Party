using MyParty.BL;
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

        public PartyController(IPartyService r)
        {
            partyService = r;
            List<PartyViewModel> partyViews = partyService.ListOfCurrentParties().OrderBy(_ => _.Date).Take(10).Select(_ => new PartyViewModel { Id = _.Id, Title = _.Title, Location = _.Location, Date = _.Date }).ToList();
            ViewBag.ListParties = partyViews;
        }

        // GET: Party
        public ActionResult Index(int id)
        {
           
            Party party = partyService.GetPartyByID(id);

            PartyParticipantsViewModel partyParticipantsViewModel = new PartyParticipantsViewModel();
            partyParticipantsViewModel.PartyID = id;
            partyParticipantsViewModel.PartyTitle = party.Title;
            partyParticipantsViewModel.PartyParticipants = partyService.ListAttendent().Where(_ => _.PartyId == id).Select(_ => new PartyParticipants { Id = _.Id, Name = _.Name, ArrivalDate = _.ArrivalDate }).ToList();

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
    }
}