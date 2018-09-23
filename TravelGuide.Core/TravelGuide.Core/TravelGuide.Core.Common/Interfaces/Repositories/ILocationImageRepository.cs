using TravelGuide.Core.Common.Entities;

namespace TravelGuide.Core.Common.Interfaces.Repositories
{
    public interface ILocationImageRepository : IRepository<LocationImage>
    {
        LocationImage GetMainImage(long locationId);
    }
}