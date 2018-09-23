using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class LocationImage : IEntity<long>
    {
        public long Id { get; set; }
        public string Path { get; set; }

        public bool IsMainImage { get; set; }

        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
