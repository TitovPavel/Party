using System.Collections.Generic;

namespace Party.Models
{
    public class Participant
    {
        public Participant()
        {
        }
        public Participant(string name, bool attend, string reason)
        {
            Name = name;
            Attend = attend;
            Reason = reason;
        }
        public string Name { get; set; }
        public bool Attend { get; set; }
        public string Reason { get; set; }
        public int Id { get; set; }

    }
}
