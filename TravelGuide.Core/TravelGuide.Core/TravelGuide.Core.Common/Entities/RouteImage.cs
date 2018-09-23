using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class RouteImage : IEntity<long>
    {
        public long Id { get; set; }
        public string Path { get; set; }

        public bool IsMainImage { get; set; }

        public long RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}
