using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyParty.ViewModels
{
    public class ParticipantViewModel
    {
        public string Name { get; set; }
        public bool Attend { get; set; }
        public string Reason { get; set; }
        [Display(Name = "Время прибытия")]
        [DataType(DataType.Time)]
        public DateTime ArrivalDate { get; set; }
        public int Id { get; set; }
        public int PartyId { get; set; }
    }
}