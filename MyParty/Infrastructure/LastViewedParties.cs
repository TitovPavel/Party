using MyParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParty.Infrastructure
{
    public class LastViewedParties : ILastViewedParties
    {
        public HttpSessionStateBase Session { get; private set; }

        public LastViewedParties() : this(new HttpSessionStateWrapper(HttpContext.Current.Session))
        { }


        public LastViewedParties(HttpSessionStateBase sessionWrapper)
        {
            Session = sessionWrapper;
        }

        
        public void AddParty(int partyId)
        {
            List<int> lastViewedParties;
            if (Session["LastViewedParties"] == null)
            {
                lastViewedParties = new List<int>();
                Session["LastViewedParties"] = lastViewedParties;
            }
            else
            {
                lastViewedParties = Session["LastViewedParties"] as List<int>;
            }

            lastViewedParties.Remove(partyId);
            lastViewedParties.Add(partyId);

        }

        public List<int> GetParties()
        {
            if (Session["LastViewedParties"] == null)
            {
                return new List<int>();
            }
            else
            {
                return Session["LastViewedParties"] as List<int>;
            }
        }
    }
}