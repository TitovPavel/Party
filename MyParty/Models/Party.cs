using System;


namespace MyParty.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}