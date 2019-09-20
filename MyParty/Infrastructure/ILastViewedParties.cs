using System.Collections.Generic;
using System.Web;


namespace MyParty.Infrastructure
{
    public interface ILastViewedParties
    {
        List<int> GetParties(HttpSessionStateBase httpSessionStateWrapper);
        void AddParty(HttpSessionStateBase httpSessionStateWrapper, int partyId);
    }
}