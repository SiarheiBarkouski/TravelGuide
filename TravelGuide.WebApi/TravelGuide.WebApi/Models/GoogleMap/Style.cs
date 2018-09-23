using System.Collections.Generic;

namespace TravelGuide.WebApiNew.Models.GoogleMap
{
  public class Style
  {
    public List<Styler> stylers { get; set; }

    public string featureType { get; set; }

    public string elementType { get; set; }
  }
}
