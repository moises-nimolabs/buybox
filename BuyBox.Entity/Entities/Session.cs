using System;

namespace BuyBox.Data.Entities
{
    public class Session
    {
        public string Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
    }
}