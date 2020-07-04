using System;

namespace BuyBox.Data.Entities
{
    public class LedgerEntry
    {
        public int Id { get; set; }
        public string Session { get; set; }
        public string Operation { get; set; }
        public Token Token { get; set; }
        public int Quantity { get; set; }
    }
}