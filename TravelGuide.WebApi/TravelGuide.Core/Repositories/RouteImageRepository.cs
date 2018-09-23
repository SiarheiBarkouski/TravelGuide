using System.Linq;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces.Repositories;

namespace TravelGuide.Core.Repositories
{
    public class RouteImageRepository : BaseRepository<RouteImage>, IRouteImageRepository
    {
        public RouteImageRepository(RepositoryContext context) : base(context)
        {
        }

        public RouteImage GetMainImage(long routeId)
        {
            return Get(x => x.RouteId == routeId && x.IsMainImage).FirstOrDefault();
        }
    }
}
