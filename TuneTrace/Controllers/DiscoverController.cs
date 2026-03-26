using Microsoft.AspNetCore.Mvc;
using TuneTrace.Repositories;

namespace TuneTrace.Controllers
{
    public class DiscoverController : Controller
    {
        private readonly ZoekRepository _zoekRepository;

        public DiscoverController(IConfiguration configuration)
        {
            _zoekRepository = new ZoekRepository(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Zoek(string zoekterm)
        {
            if (string.IsNullOrWhiteSpace(zoekterm) || zoekterm.Length < 2)
            {
                TempData["Fout"] = "Please enter at least 2 characters.";
                return RedirectToAction("Index");
            }

            // Recente zoekopdrachten opslaan in sessie
            var recente = HttpContext.Session.GetString("RecentSearchhistory");
            var lijst = recente != null ? recente.Split(',').ToList() : new List<string>();
            lijst.Remove(zoekterm);
            lijst.Insert(0, zoekterm);
            if (lijst.Count > 5) lijst = lijst.Take(5).ToList();
            HttpContext.Session.SetString("RecentSearchhistory", string.Join(',', lijst));

            ViewBag.Zoekterm = zoekterm;
            ViewBag.Artiesten = _zoekRepository.ZoekArtiesten(zoekterm);
            ViewBag.Albums = _zoekRepository.ZoekAlbums(zoekterm);
            ViewBag.Songs = _zoekRepository.ZoekSongs(zoekterm);
            ViewBag.RecenteZoekopdrachten = lijst;

            return View("Index");
        }
    }
}