using System.Collections.Generic;
using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class Country : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}