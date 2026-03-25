using Microsoft.AspNetCore.Mvc;

namespace TuneTrace.Controllers
{
    public class DiscoverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
