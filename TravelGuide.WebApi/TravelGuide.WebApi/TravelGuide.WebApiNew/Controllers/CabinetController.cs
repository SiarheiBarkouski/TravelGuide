using Microsoft.AspNetCore.Mvc;

namespace TravelGuide.WebApi.Controllers
{
    public class CabinetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}