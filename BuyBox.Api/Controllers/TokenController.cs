using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyBox.Api.Controllers
{
    /// <summary>
    ///     Controller used to Add user tokens.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        ///     Adds a User <see cref="TokenModel" />
        /// </summary>
        /// <param name="model">The underlying token, only the <see cref="TokenModel" /> id is required as parameter</param>
        /// <returns>
        ///     The persisted <see cref="TokenModel" />
        /// </returns>
        [HttpPost]
        public async Task<TokenModel> Post(TokenModel model)
        {
            var sessionId = Request.Cookies["session"];
            return await _tokenService.InsertCoin(model, sessionId);
        }
    }
}