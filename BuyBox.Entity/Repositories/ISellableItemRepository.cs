using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Data.Entities;

namespace BuyBox.Data.Repositories
{
    /// <summary>
    ///     Performs the most common <see cref="SellableItem" />
    ///     operations
    /// </summary>
    public interface ISellableItemRepository
    {
        /// <summary>
        ///     Exposes the <see cref="SellableItem" /> available in the system
        ///     as a catalog.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SellableItem>> List();

        /// <summary>
        ///     Finds a specific <see cref="SellableItem" /> by it's id.
        /// </summary>
        /// <param name="id">The id of the <see cref="SellableItem" /></param>
        /// <returns>The chosen <see cref="SellableItem" /></returns>
        Task<SellableItem> Find(int id);

        /// <summary>
        ///     Deducts a specific sellable item from the stock.
        ///     It doesn't change the <see cref="SellableItem" />, instead it will create
        ///     a stock history for a specific product.
        /// </summary>
        /// <param name="resultSellableItem"></param>
        /// <returns></returns>
        Task DeductStock(SellableItem resultSellableItem);
    }
}