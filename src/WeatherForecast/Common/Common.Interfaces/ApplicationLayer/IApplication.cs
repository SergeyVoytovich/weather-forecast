using System.Threading.Tasks;
using Common.Interfaces.Models;

namespace Common.Interfaces.ApplicationLayer
{
    /// <summary>
    /// Interface for application
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Get city weather
        /// </summary>
        /// <param name="query">Query for search (city name or city zipcode)</param>
        /// <returns></returns>
        Task<ICity> GetAsync(string query);
    }
}