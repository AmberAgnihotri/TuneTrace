using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using serviceLibary.Services;
using ServiceLibrary.Services;
using TuneTrace.ViewModels;

namespace TuneTrace.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        private readonly SongService _songService;
        private readonly AlbumService _albumService;

        public ReviewController(IConfiguration configuration)
        {
            _reviewService = new ReviewService(new ReviewRepository(configuration));
            _songService = new SongService(new SongRepository(configuration));
            _albumService = new AlbumService(new AlbumRepository(configuration));
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
                ViewBag.Error = "You already have a review for this song. Please delete your current review before placing a new one.";
                return View("Index", vm);
            }

            if (vm.AlbumId > 0 && _reviewService.HasAlbumReview(vm.UserId, vm.AlbumId))
            {
                ViewBag.Error = "You already have a review for this album. Please delete your current review before placing a new one.";
                return View("Index", vm);
            }

            if (vm.Rating < 1 || vm.Rating > 10)
            {
                ViewBag.Error = "Rating must be between 1 and 10.";
                return View("Index", vm);
            }

            if (vm.SongId > 0)
                _reviewService.AddReview(vm.UserId, vm.SongId, vm.ReviewText, vm.Rating);
            else if (vm.AlbumId > 0)
                _reviewService.AddAlbumReview(vm.UserId, vm.AlbumId, vm.ReviewText, vm.Rating);

            return RedirectToAction("Index");
        }
    }
}