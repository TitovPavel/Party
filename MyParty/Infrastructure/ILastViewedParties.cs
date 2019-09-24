using System.Collections.Generic;
using System.Web;


namespace MyParty.Infrastructure
{
    public interface ILastViewedParties
    {
        List<int> GetParties();
        void AddParty(int partyId);
    }
}