using MyParty.BL;
using MyParty.Models;
using MyParty.ViewModels;
using System;
using System.Collections.Generic;
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

        public ActionResult Save(ParticipantViewModel participantViewModel)
        {

            Participant participant = new Participant
            {
                Id = participantViewModel.Id,
                ArrivalDate = participantViewModel.ArrivalDate,
                Attend = participantViewModel.Attend,
                Name = participantViewModel.Name,
                PartyId = participantViewModel.PartyId,
                Reason = participantViewModel.Reason,
            };

            partyService.Vote(participant);
            return RedirectToAction("Index", new {id = participantViewModel.PartyId});
        }
    }
}