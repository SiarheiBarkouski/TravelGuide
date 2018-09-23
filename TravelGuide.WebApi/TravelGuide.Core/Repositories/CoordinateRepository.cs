using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces.Repositories;

namespace TravelGuide.Core.Repositories
{
    public class CoordinateRepository : BaseRepository<Coordinate>, ICoordinateRepository
    {
        public CoordinateRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
