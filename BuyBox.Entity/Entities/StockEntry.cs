namespace BuyBox.Data.Entities
{
    public class StockEntry
    {
        // ReSharper disable once UnusedMember.Global
        public int Id { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Product Product { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Operation { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Quantity { get; set; }
    }
}