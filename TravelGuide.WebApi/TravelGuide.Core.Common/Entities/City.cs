using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class City : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}