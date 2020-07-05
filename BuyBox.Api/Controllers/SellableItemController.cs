using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyBox.Api.Controllers
{
    /// <summary>
    ///     Enables the Purchase of a Single item.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SellableItemController : ControllerBase
    {
        private readonly ISellableItemService _service;

        public SellableItemController(ISellableItemService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Gets the specific item.
        ///     This call requires a frontend confirmation, otherwise it'll subtract
        ///     right away tokens and the user will get the product.
        /// </summary>
        /// <param name="id"><see cref="SellableItemModel" /> id</param>
        /// <returns>
        ///     A <see cref="PurchaseModel" /> which contains relevant order information
        ///     or a message explaining why it's not possible to buy.
        /// </returns>
        [HttpGet]
        public async Task<PurchaseModel> Get(int id)
        {
            var session = Request.Cookies["session"];
            return await _service.OrderItem(id, session);
        }
    }
}