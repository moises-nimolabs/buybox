using System.Threading.Tasks;
using BuyBox.Domain.Models;

namespace BuyBox.Domain.Services
{
    /// <summary>
    ///     Used to create or finish User Interaction sessions.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        ///     Creates a user session.
        /// </summary>
        /// <returns>An instance <see cref="SessionModel" /> which represents the User Interaction.</returns>
        Task<SessionModel> New();

        /// <summary>
        ///     Finishes a user <see cref="SessionModel" />
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SessionModel> Finish(string id);
    }
}