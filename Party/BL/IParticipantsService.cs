using Party.Models;
using System.Collections.Generic;

namespace Party.BL
{
    public interface IParticipantsService
    {
        List<Participant> ListAll();
        List<Participant> ListAttendent();
        List<Participant> ListMissed();
        void Vote(string name, bool attend, string reason);
    }
}