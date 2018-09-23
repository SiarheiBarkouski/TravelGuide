using System.Collections.Generic;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.WebApiNew.Models.GoogleMap
{
    public class Map
    {
        public Map()
        {
            center = new Center
            {
                latitude = 53.8906,
                longitude = 27.5137
            };
            locations = new List<Location>();
            style = new List<Style>();
            markerPinFiles = new List<string>
            {
        "flag-azure.png",
        "flag-green.png",
        "needle-pink.png",
        "niddle-green.png",
        "pin-azure.png",
        "pin-green.png",
        "pin-pink.png"
      };
            drawingTools = new List<string>
            {
        "marker",
        "polyline",
        "polygon",
        "circle",
        "rectangle"
      };
            editTemplatesPath = "../html/";
            markerPinsPath = "../img/pin/";
            drawingBorderColor = "#ff0000";
            drawingBorderWidth = 2;
            drawingFillColor = "#ffff00";
            zoom = 13;
            language = "en";
            stylesPath = "../styles.json";
            zoomControl = true;
            panControl = true;
            scaleControl = true;
            streetViewControl = true;
            scrollWheel = true;
            richtextEditor = true;
            searchBox = true;
            width = 1000;
            height = 400;
        }

        public bool editMode { get; set; }

        public string editTemplatesPath { get; set; }

        public string markerPinsPath { get; set; }

        public List<string> markerPinFiles { get; set; }

        public string drawingBorderColor { get; set; }

        public int drawingBorderWidth { get; set; }

        public string drawingFillColor { get; set; }

        public int zoom { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public bool singleLocation { get; set; }

        public Center center { get; set; }

        public string language { get; set; }

        public bool searchBox { get; set; }

        public bool richtextEditor { get; set; }

        public List<string> drawingTools { get; set; }

        public bool zoomControl { get; set; }

        public bool panControl { get; set; }

        public bool scaleControl { get; set; }

        public bool streetViewControl { get; set; }

        public bool scrollWheel { get; set; }

        public string stylesPath { get; set; }

        public List<Style> style { get; set; }

        public List<Location> locations { get; set; }

        public long routeId { get; set; }
    }
}
