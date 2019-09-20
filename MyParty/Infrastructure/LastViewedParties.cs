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
        public void AddParty(HttpSessionStateBase httpSessionStateWrapper, int partyId)
        {
            List<int> lastViewedParties;
            if (httpSessionStateWrapper["LastViewedParties"] == null)
            {
                lastViewedParties = new List<int>();
                httpSessionStateWrapper["LastViewedParties"] = lastViewedParties;
            }
            else
            {
                lastViewedParties = httpSessionStateWrapper["LastViewedParties"] as List<int>;
            }

            lastViewedParties.Remove(partyId);
            lastViewedParties.Add(partyId);

        }

        public List<int> GetParties(HttpSessionStateBase httpSessionStateWrapper)
        {
            if (httpSessionStateWrapper["LastViewedParties"] == null)
            {
                return new List<int>();
            }
            else
            {
                return httpSessionStateWrapper["LastViewedParties"] as List<int>;
            }
        }
    }
}