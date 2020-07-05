using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuyBox.Data.Entities;
using BuyBox.Data.Repositories;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services.Impl
{
    public class SellableItemService : ISellableItemService
    {
        private readonly ILedgerRepository _ledgerRepository;
        private readonly IMapper _mapper;
        private readonly ISellableItemRepository _sellableItemRepository;
        private readonly ITokenService _tokenService;

        public SellableItemService(IMapper mapper, ISellableItemRepository sellableItemRepository,
            ILedgerRepository ledgerRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _sellableItemRepository = sellableItemRepository;
            _ledgerRepository = ledgerRepository;
        }

        public async Task<SellableItemModelCollection> GetCollection()
        {
            var sellableItems = await _sellableItemRepository.List();
            return _mapper.Map<SellableItemModelCollection>(sellableItems);
        }

        public async Task<PurchaseModel> OrderItem(int id, string sessionId)
        {
            //by default you can buy the item
            var result = new PurchaseModel
            {
                CanBuy = true,
                SellableItem = _mapper.Map<SellableItemModel>(await _sellableItemRepository.Find(id)),
                InsertedTokens = await _tokenService.GetCollection(sessionId)
            };
            //always deduct only one item per purchase

            //no stock available
            if (result.SellableItem.Quantity == 0)
            {
                result.Message = "The item is out of stock";
                result.CanBuy = false;
            }

            //define 1 to be deducted later from the stock
            result.SellableItem.Quantity = 1;


            //not enough money to buy
            if (result.InsertedTokens.Total < result.SellableItem.Price)
            {
                double remainingMoney = result.SellableItem.Price - result.InsertedTokens.Total;

                result.Message =
                    $"Insufficient money. You need to add at least {remainingMoney / 100} eur to buy this item";
                result.CanBuy = false;
            }

            if (!result.CanBuy)
                return result;

            if (result.InsertedTokens.Total != result.SellableItem.Price)
            {
                var exchangeTokens = await _ledgerRepository.GetExchangeTokens();
                var giveBack = result.InsertedTokens.Total - result.SellableItem.Price;
                var tokensToExchange = new List<ExchangeToken>();
                while (giveBack > 0 && result.CanBuy)
                    foreach (var t in exchangeTokens)
                    {
                        if (giveBack / t.Value <= 0)
                            continue;
                        if (t.Quantity == 0)
                        {
                            result.CanBuy = false;
                            result.Message = "The machine doesn't have enough exchange tokens, ask for help.";
                        }

                        giveBack -= t.Value;
                        t.Quantity--;
                        tokensToExchange.Add(t);
                        break;
                    }

                result.ExchangeTokens = _mapper.Map<TokenModelCollection>(tokensToExchange);
                await _ledgerRepository.AddExchangeTokens(sessionId, tokensToExchange);
            }

            var subtracted = await _ledgerRepository.Subtract(sessionId, result.SellableItem.Price);
            var subtractedTokens = subtracted.Select(p => p.Token);
            await _sellableItemRepository.DeductStock(_mapper.Map<SellableItem>(result.SellableItem));

            result.Message = "Thanks for your order";
            result.SubtractedTokens = _mapper.Map<TokenModelCollection>(subtractedTokens);
            return result;
        }
    }
}