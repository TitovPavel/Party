using MyParty.Models;
using System.Collections.Generic;

namespace MyParty.DAL
{
    interface IParticipantsRepository
    {
        void Delete(string name);
        List<Participant> List();
        void Save(List<Participant> p);
    }
}