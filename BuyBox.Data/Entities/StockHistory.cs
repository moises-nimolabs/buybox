namespace BuyBox.Data.Entities
{
    public class StockHistory
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Operation { get; set; }
        public int Quantity { get; set; }
    }
}