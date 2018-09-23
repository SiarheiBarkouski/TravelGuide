using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces.Repositories;

namespace TravelGuide.Core.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
