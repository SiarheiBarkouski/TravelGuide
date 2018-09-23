using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelGuide.WebApiNew.Models
{
    public class RouteConstructorModel
    {
        public int Mode { get; set; }

        public List<SelectListItem> Routes { get; set; }

        public long Id { get; set; }

        [Required(ErrorMessage = "Please fill in the name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill in the description.")]
        public string Description { get; set; }

        public long ImageId { get; set; }

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please choose a city.")]
        public int CityId { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}