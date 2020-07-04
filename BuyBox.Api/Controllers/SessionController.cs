using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyBox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<CoinController> _logger;

        public SessionController(ILogger<CoinController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public SessionModel Get()
        {
            return new SessionModel()
            {
                Id = HttpContext.Session.Id
            };
        }
    }
}