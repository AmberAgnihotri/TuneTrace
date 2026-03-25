using Microsoft.AspNetCore.Mvc;
using TuneTrace.Repositories;

namespace TuneTrace.Controllers
{
    public class BeoordelingController : Controller
    {
        private readonly BeoordelingRepository _beoordelingRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly SongRepository _songRepository;

        public BeoordelingController(IConfiguration configuration)
        {
            _beoordelingRepository = new BeoordelingRepository(configuration);
            _albumRepository = new AlbumRepository(configuration);
            _songRepository = new SongRepository(configuration);
        }

        public IActionResult Index()
        {
            int gebruikerId = 1; // tijdelijk vast
            ViewBag.Albums = _albumRepository.GetAlbums();
            ViewBag.Songs = _songRepository.GetSongs();
            ViewBag.Beoordelingen = _beoordelingRepository.GetBeoordelingenVanGebruiker(gebruikerId);
            return View();
        }

        [HttpPost]
        public IActionResult Opslaan(int? albumId, int? songId, int rating, string review)
        {
            int gebruikerId = 1; // tijdelijk vast

            if (_beoordelingRepository.HeeftActieveBeoordeling(gebruikerId, albumId, songId))
            {
                TempData["Wrong"] = "You already have an active rating & review. Please delete the existing one before submitting a new one.";
                return RedirectToAction("Index");
            }

            _beoordelingRepository.VoegBeoordelingToe(gebruikerId, albumId, songId, rating, review);
            TempData["Succes"] = "Review & Rating saved!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Verwijderen(int beoordelingId)
        {
            _beoordelingRepository.VerwijderBeoordelingOpId(beoordelingId);
            TempData["Succes"] = "Review & Rating deleted!";
            return RedirectToAction("Index");
        }
    }
}





