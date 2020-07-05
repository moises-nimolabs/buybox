using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyBox.Api.Controllers
{
    /// <summary>
    ///     Provides SellableItems access.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SellableItemsController : ControllerBase
    {
        private readonly ISellableItemService _service;

        public SellableItemsController(ISellableItemService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Provides a List of <see cref="SellableItemModel" />
        /// </summary>
        /// <returns>The available collection of <see cref="SellableItemModel" /></returns>
        [HttpGet]
        public async Task<SellableItemModelCollection> Get()
        {
            return await _service.GetCollection();
        }
    }
}