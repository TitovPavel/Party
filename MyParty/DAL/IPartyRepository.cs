using System.Collections.Generic;
using MyParty.Models;

namespace MyParty.DAL
{
    interface IPartyRepository
    {
        void Delete(Party party);
        List<Party> List();
        void Save(List<Party> p);
        Party GetByID(int id);
    }
}
