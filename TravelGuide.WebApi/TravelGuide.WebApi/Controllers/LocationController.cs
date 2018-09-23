using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces;
using TravelGuide.WebApiNew.Models;

namespace TravelGuide.WebApiNew.Controllers
{
    public class LocationController : Controller
    {
        private readonly IUnitOfWork _uow;

        public LocationController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult LocationConstructor(LocationConstructorModel model)
        {
            var locations = _uow.Routes.Get(model.RouteId).Locations.ToList();
            model.Locations = locations;

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveLocations([FromBody] List<Location> newLocations)
        {
            var x = 1;

            return null;
        }
    }
}