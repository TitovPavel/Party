using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MyParty.Models;
using Newtonsoft.Json;

namespace MyParty.DAL
{
    public class PartyRepository : IPartyRepository
    {

        string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Parties.json");
        List<Party> parties;


        public void Delete(Party party)
        {
            parties.RemoveAll(x => x.Title == party.Title);
            Save(parties);
        }

        public Party GetByID(int id)
        {
            if (parties == null)
                parties = List();

            Party party = parties.FirstOrDefault(_ => _.Id == id);
            return party;

        }

        public List<Party> List()
        {
            if (!File.Exists(_path))
                return new List<Party>();

            if (parties == null)
            {
                using (StreamReader file = new StreamReader(_path))
                {
                    String participantsString = file.ReadToEnd();
                    parties = JsonConvert.DeserializeObject(participantsString, typeof(List<Party>)) as List<Party>;
                }
            }
            return parties;
        }

        public void Save(List<Party> p)
        {
            if (!File.Exists(_path))
                return;

            using (StreamWriter fs = new StreamWriter(_path))
            {
                fs.Write(JsonConvert.SerializeObject(p));
            }
        }
    }
}