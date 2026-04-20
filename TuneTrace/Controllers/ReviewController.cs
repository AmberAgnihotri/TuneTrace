
using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Services;
using BLL.Services;
using TuneTrace.ViewModels;

namespace TuneTrace.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        private readonly SongService _songService;
        private readonly AlbumService _albumService;

        public ReviewController(ReviewService reviewService, SongService songService, AlbumService albumService)
        {
            _reviewService = reviewService;
            _songService = songService;
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            ViewBag.Songs = _songService.GetSongs();
            ViewBag.Albums = _albumService.GetAll();
            ViewBag.Reviews = _reviewService.GetAllReviews();
            return View();
        }

        [HttpPost]
        public IActionResult AddReview(ReviewViewModel vm)
        {
            ViewBag.Songs = _songService.GetSongs();
            ViewBag.Albums = _albumService.GetAll();
            ViewBag.Reviews = _reviewService.GetAllReviews();

            if (vm.SongId > 0 && _reviewService.HasSongReview(vm.UserId, vm.SongId))
            {
                ViewBag.Error = "Je hebt al een review voor dit nummer. Verwijder je huidige review eerst voordat je een nieuwe kunt plaatsen.";
                return View("Index", vm);
            }

            if (vm.AlbumId > 0 && _reviewService.HasAlbumReview(vm.UserId, vm.AlbumId))
            {
                ViewBag.Error = "Je hebt al een review voor dit album. Verwijder je huidige review eerst voordat je een nieuwe kunt plaatsen.";
                return View("Index", vm);
            }

            if (vm.Rating < 1 || vm.Rating > 10)
            {
                ViewBag.Error = "Rating moet tussen 1 en 10 zijn.";
                return View("Index", vm);
            }

            _reviewService.AddReview(vm.UserId, vm.SongId, vm.ReviewText, vm.Rating);
            return RedirectToAction("Index");
        }
    }
}