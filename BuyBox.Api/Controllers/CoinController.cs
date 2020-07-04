using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyBox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<CoinController> _logger;

        public CoinController(ILogger<CoinController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }
        
        //TODO: Add a get for the inserted coins
        
        [HttpPost]
        public async Task<CoinModel> Post(CoinModel model)
        {
            await _tokenService.InsertCoin(model);
            return model;
        }
        
        [HttpDelete]
        public async Task Delete(string id)
        {
            await _tokenService.Cancel(id);
        }
    }
}