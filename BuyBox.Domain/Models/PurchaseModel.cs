namespace BuyBox.Domain.Models
{
    public class PurchaseModel
    {
        public bool CanBuy { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Message { get; set; }
        public SellableItemModel SellableItem { get; set; }
        public TokenModelCollection InsertedTokens { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public TokenModelCollection SubtractedTokens { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public TokenModelCollection ExchangeTokens { get; set; }
    }
}