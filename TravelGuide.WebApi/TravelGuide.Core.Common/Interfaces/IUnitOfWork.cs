using System.Threading.Tasks;
using TravelGuide.Core.Common.Interfaces.Repositories;

namespace TravelGuide.Core.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository Cities { get; }

        ICoordinateRepository Coordinates { get; }

        ICountryRepository Countries { get; }

        IRouteImageRepository RouteImages { get; }

        ILocationRepository Locations { get; }

        IRouteRepository Routes { get; }

        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
        Task InitializeDatabase();
    }
}