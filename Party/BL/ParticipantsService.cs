using Party.DAL;
using Party.Models;
using System.Collections.Generic;
using System.Linq;

namespace Party.BL
{
    class ParticipantsService : IParticipantsService
    {
        IParticipantsRepository participantsRepository;

        public ParticipantsService(IParticipantsRepository participantsRepository)
        {
            this.participantsRepository = participantsRepository;
        }

        public void Vote(string name, bool attend, string reason)
        {
            bool newParticipant = true;
            bool saveParticipant = true;

            List<Participant> participants = participantsRepository.List();
            foreach (var p in participants)
            {
                if(p.Name == name)
                {
                    if (p.Attend != attend)
                    {
                        p.Attend = attend;
                        p.Reason = reason;
                    }
                    else
                    {
                        saveParticipant = false;
                    }
                    newParticipant = false;
                    continue;
                }
            }
            if (newParticipant)
            {
                participants.Add(new Participant(name, attend, reason));
            }

            if (saveParticipant)
            {
                participantsRepository.Save(participants);
            }

        }

        public List<Participant> ListAll()
        {
            return participantsRepository.List();
        }

        public List<Participant> ListAttendent()
        {
            return participantsRepository.List().Where(p=>p.Attend == true).ToList();
        }
        public List<Participant> ListMissed()
        {
            return participantsRepository.List().Where(p => p.Attend == false).ToList();
        }
    }
}
