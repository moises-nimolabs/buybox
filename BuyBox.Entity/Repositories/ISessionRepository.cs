using System.Threading.Tasks;
using BuyBox.Data.Entities;

namespace BuyBox.Data.Repositories
{
    /// <summary>
    ///     Allows the start and finish of an interaction section.
    ///     Used by each user interaction.
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        ///     Creates a new <see cref="Session" />
        /// </summary>
        /// <returns>The underlying session</returns>
        Task<Session> New();

        /// <summary>
        ///     Finishes a session.
        /// </summary>
        /// <param name="id">Id of the session to be finished</param>
        /// <returns></returns>
        Task<Session> Finish(string id);
    }
}