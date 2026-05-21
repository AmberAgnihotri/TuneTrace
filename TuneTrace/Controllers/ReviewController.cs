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
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "User");

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                ViewBag.Songs = _songService.GetSongs();
                ViewBag.Albums = _albumService.GetAll();
                ViewBag.Reviews = _reviewService.GetReviewsByUser(userId);
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while loading the reviews.";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddReview(ReviewViewModel vm)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "User");

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                ViewBag.Songs = _songService.GetSongs();
                ViewBag.Albums = _albumService.GetAll();
                ViewBag.Reviews = _reviewService.GetReviewsByUser(userId);

                if (vm.SongId > 0 && _reviewService.HasSongReview(userId, vm.SongId))
                {
                    ViewBag.Error = "You already have a review for this song. Please delete your current review before placing a new one.";
                    return View("Index", vm);
                }

                if (vm.AlbumId > 0 && _reviewService.HasAlbumReview(userId, vm.AlbumId))
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
                    _reviewService.AddReview(userId, vm.SongId, vm.ReviewText, vm.Rating);
                else if (vm.AlbumId > 0)
                    _reviewService.AddAlbumReview(userId, vm.AlbumId, vm.ReviewText, vm.Rating);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while adding the review.";
                return View("Index", vm);
            }
        }
    }
}