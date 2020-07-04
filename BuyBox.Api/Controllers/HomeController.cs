using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyBox.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyBox.Api.Controllers
{
    /// <summary>
    /// Exposes the Home Api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HomeResponseModel Get()
        {
            return new HomeResponseModel()
            {
                Message = "BuyBox Home Api"
            };
        }
    }
}