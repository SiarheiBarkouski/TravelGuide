using System.Collections.Generic;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.WebApiNew.Models
{
    public class LocationConstructorModel
    {
        public List<Location> Locations { get; set; }

        public long RouteId { get; set; }
    }
}