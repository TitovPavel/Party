﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyParty.ViewModels
{
    public class PartyViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

    }
}