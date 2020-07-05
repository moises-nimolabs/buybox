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
    public class TokensController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokensController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        ///     Retrieves the user added tokens for frontend update purposes.
        ///     This method is usually called to inform the current user available <see cref="TokenModel" />
        /// </summary>
        /// <returns>
        ///     A collection of <see cref="TokenModel" /> represented by
        ///     a <see cref="TokenModelCollection" />
        /// </returns>
        [HttpGet]
        public async Task<TokenModelCollection> Get()
        {
            var sessionId = Request.Cookies["session"];
            return await _tokenService.GetCollection(sessionId);
        }

        [HttpDelete]
        public async Task<TokenModelCollection> Delete()
        {
            var sessionId = Request.Cookies["session"];
            return await _tokenService.CancelAndRetrieveInserted(sessionId);
        }
    }
}