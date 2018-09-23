using System.Collections.Generic;
using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class Location : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Radius { get; set; }
        public string Icon { get; set; }
        public string HoverIcon { get; set; }
        public string LocationType { get; set; }
        public int LocationOrder { get; set; }

        public virtual List<LocationImage> LocationImages { get; set; }
        public virtual List<Coordinate> Coordinates { get; set; }
    }
}