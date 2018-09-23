using TravelGuide.Core.Common.Entities;

namespace TravelGuide.Core.Common.Interfaces.Repositories
{
    public interface IRouteImageRepository : IRepository<RouteImage>
    {
        RouteImage GetMainImage(long routeId);
    }
}