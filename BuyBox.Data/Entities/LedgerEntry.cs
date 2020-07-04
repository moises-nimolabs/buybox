using System;

namespace BuyBox.Data.Entities
{
    public class LedgerEntry
    {
        public int Id { get; set; }
        public DateTime Transaction { get; set; }
        public DateTime When { get; set; }
        public string Operation { get; set; }
        public Token Token { get; set; }
        public int Quantity { get; set; }
    }
}