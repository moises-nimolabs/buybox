using Microsoft.AspNetCore.Mvc;

namespace BuyBox.Api.Controllers
{
    /// <summary>
    ///     Exposes the Home Api to the Swagger Service descriptor
    /// </summary>
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        ///     Performs a redirect to the swagger documentation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedirectResult Get()
        {
            return RedirectPermanent("/swagger/");
        }
    }
}