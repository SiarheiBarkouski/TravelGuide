using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Common.Interfaces;
using TravelGuide.WebApiNew.Helpers;
using TravelGuide.WebApiNew.Models;

namespace TravelGuide.WebApiNew.Controllers
{
    public class RouteController : Controller
    {
        private readonly IUnitOfWork _uow;
        private IHostingEnvironment _env;

        public RouteController(IUnitOfWork uow, IHostingEnvironment env)
        {
            _uow = uow;
            _env = env;
        }

        [HttpGet]
        public ActionResult RouteConstructor(int? mode)
        {
            RouteConstructorModel model;
            var routes = _uow.Routes.Get().OrderBy(x => x.Id).ToList();

            if (mode.HasValue && mode.Value == 1 || !routes.Any())
            {
                model = new RouteConstructorModel
                {
                    Id = 0,
                    Name = string.Empty,
                    Description = string.Empty,
                    ImageId = 0,
                    Cities = _uow.Cities.Get().ToSelectItemList(),
                    Routes = new List<SelectListItem>(),
                    Mode = 1
                };
            }
            else
            {
                

                model = new RouteConstructorModel
                {
                    Id = routes.First().Id,
                    Name = routes.First().Name,
                    Description = routes.First().Description,
                    ImageId = _uow.RouteImages.GetMainImage(routes.First().Id)?.Id ?? 0,
                    CityId = routes.First().City.Id,
                    Cities = _uow.Cities.Get().ToSelectItemList(),
                    Routes = routes.ToSelectItemList(),
                    Mode = 2
                };
            }

            return View(model);
        }

        //[HttpGet]
        //public IActionResult Get(long id)
        //{
        //    var result = _uow.Routes.Get(id);
        //    return Ok(result);
        //}

        [HttpGet]
        public IActionResult Get()
        {
            var result = _uow.Routes.Get().ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveRoute(RouteConstructorModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.Mode == 2)
                {
                    model.Routes = _uow.Routes.Get().ToSelectItemList();
                }

                model.Cities = _uow.Cities.Get().ToSelectItemList();
                return View("RouteConstructor", model);
            }

            var cityId = model.CityId == 0 ? 1 : model.CityId;
            var city = _uow.Cities.Get(cityId);
            var route = new Route
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                City = city
            };

            if (model.Id == 0)
            {
                _uow.Routes.Add(route);
                if (model.Image != null)
                {
                    var filename = model.Image.FileName;
                    var filePathOriginal = Path.Combine(_env.WebRootPath, "Uploads/Originals");
                    var filePathReadyForUse = Path.Combine(_env.WebRootPath, "Uploads/ReadyForUse");
                    if (model.Image.Length > 0)
                    {
                        using (var stream = new FileStream(Path.Combine(filePathOriginal, filename), FileMode.Create))
                        {
                            await model.Image.CopyToAsync(stream);
                        }
                    }

                    using (var srcImage = System.Drawing.Image.FromFile(Path.Combine(filePathOriginal, filename)))
                    using (var newImage = new Bitmap(100, 100))
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(srcImage, new Rectangle(0, 0, 200, 200));
                        var path = Path.Combine(filePathReadyForUse,
                            filename.Replace(filename.Substring(filename.LastIndexOf(".")), ".png"));
                        newImage.Save(path, ImageFormat.Png);
                        var image = new RouteImage { Path = path, Route = route};
                        var result = _uow.RouteImages.Add(image);
                        route.RouteImages.Add(result);
                    }
                }
                
                await _uow.SaveChangesAsync();
            }
            else
            {
                var existingRoute = _uow.Routes.Get(route.Id);
                _uow.Routes.Update(existingRoute);
                await _uow.SaveChangesAsync();
            }
            return RedirectToAction("LocationConstructor", "Location", new LocationConstructorModel { RouteId = route.Id });
        }

        [HttpGet]
        public JsonResult GetRouteInfo()
        {
            using (this)
            {

            }

            return null;
        }


        [HttpGet]
        public FileResult GetRouteImage(long routeImageId)
        {
            var image = _uow.RouteImages.Get(routeImageId);
            if (image != null)
            {
                return File(image.Path, "image/png");
            }

            return null;
        }
    }
}