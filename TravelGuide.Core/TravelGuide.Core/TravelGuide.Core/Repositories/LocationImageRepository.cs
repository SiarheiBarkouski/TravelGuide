using System.Linq;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces.Repositories;

namespace TravelGuide.Core.Repositories
{
    public class LocationImageRepository : BaseRepository<LocationImage>, ILocationImageRepository
    {
        public LocationImageRepository(RepositoryContext context) : base(context)
        {
        }

        public LocationImage GetMainImage(long locationId)
        {
            return Get(x => x.LocationId == locationId && x.IsMainImage).FirstOrDefault();
        }
    }
}
