using System.Threading.Tasks;
using BuyBox.Domain.Models;
using BuyBox.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyBox.Api.Controllers
{
    /// <summary>
    ///     Starts a Session for the BuyBox Interaction
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        /// <summary>
        ///     Gets the initial cookie for the machine interaction.
        /// </summary>
        /// <returns>A cookie for the further interactions.</returns>
        [HttpHead]
        public async Task Head()
        {
            var sessionId = Request.Cookies["session"];
            if (string.IsNullOrEmpty(sessionId))
            {
                var session = await _sessionService.New();
                Response.Cookies.Append("session", session.Id);    
            }
        }

        /// <summary>
        ///     Finishes the Interaction session and removes the cookie.
        /// </summary>
        /// <param name="model">The <see cref="SessionModel" /> object used in the session</param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<SessionModel> Post(SessionModel model)
        {
            Response.Cookies.Delete("session");
            return await _sessionService.Finish(model.Id);
        }
    }
}