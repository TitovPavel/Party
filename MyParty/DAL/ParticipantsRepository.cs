using MyParty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyParty.DAL
{
    class ParticipantsRepository : IParticipantsRepository
    {
        
        string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Participants.json");

        List<Participant> participants;

        public List<Participant> List()
        {
            if (!File.Exists(_path))
                return new List<Participant>();

            if (participants == null)
            {
                using (StreamReader file = new StreamReader(_path))
                {
                    String participantsString = file.ReadToEnd();
                    participants = JsonConvert.DeserializeObject(participantsString, typeof(List<Participant>)) as List<Participant>;
                }
            }
            return participants;
        }

        public void Save(List<Participant> p)
        {
            if (!File.Exists(_path))
                return;

            using (StreamWriter fs = new StreamWriter(_path))
            {
                fs.Write(JsonConvert.SerializeObject(p));
            }

        }

        public void Delete(string name)
        {
            participants.RemoveAll(x => x.Name == name);
            Save(participants);
        }
    }
}
