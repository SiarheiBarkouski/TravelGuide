using System.Collections.Generic;
using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class Route : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual City City { get; set; }
        public virtual List<RouteImage> RouteImages { get; set; }
        public virtual List<Location> Locations { get; set; }
    }
}