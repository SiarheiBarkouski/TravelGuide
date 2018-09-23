using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class Coordinate : IEntity<long>
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long LocationId { get; set; }
        
        public virtual Location Location { get; set; }
    }
}