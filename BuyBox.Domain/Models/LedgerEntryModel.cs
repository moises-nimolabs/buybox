using System;

namespace BuyBox.Domain.Models
{
    public class LedgerEntry
    {
        public int Id { get; set; }
        public string Session { get; set; }
        public string Operation { get; set; }
        public CoinModel CoinModel { get; set; }
        public int Quantity { get; set; }
    }
}