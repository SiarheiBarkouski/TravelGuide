using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces.Repositories;

namespace TravelGuide.Core.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
