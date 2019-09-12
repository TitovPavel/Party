using Party.Models;
using System.Collections.Generic;

namespace Party.DAL
{
    interface IParticipantsRepository
    {
        void Delete(string name);
        List<Participant> List();
        void Save(List<Participant> p);
    }
}