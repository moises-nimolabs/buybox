﻿namespace BuyBox.Domain.Models
{
    public class SellableItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}