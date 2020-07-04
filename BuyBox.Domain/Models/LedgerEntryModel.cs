using System;

namespace BuyBox.Domain.Models
{
    public class LedgerEntry
    {
        public int Id { get; set; }
        public DateTime Transaction { get; set; }
        public DateTime When { get; set; }
        public string Operation { get; set; }
        public TokenModel TokenModel { get; set; }
        public int Quantity { get; set; }
    }
}