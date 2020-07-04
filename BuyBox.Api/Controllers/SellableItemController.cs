using System.Collections.Generic;
using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyBox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellableItemController : ControllerBase
    {
        private ILogger<SellableItemController> _logger;
        private ISellableItemService _service;

        public SellableItemController(ILogger<SellableItemController> logger, ISellableItemService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet, Route("[action]")]
        public async Task<IEnumerable<SellableItemModel>> List()
        {
            return await _service.List();
        }
    }
}