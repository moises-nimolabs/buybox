namespace BuyBox.Data.Entities
{
    public class LedgerEntry
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Id { get; set; }
        public Session Session { get; set; }
        public LedgerEntry Related { get; set; }
        public Token Token { get; set; }
        public string Operation { get; set; }
    }
}