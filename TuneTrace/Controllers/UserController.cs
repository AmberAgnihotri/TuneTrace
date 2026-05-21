using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using serviceLibary.Services;
using ServiceLibrary.Services;

namespace TuneTrace.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly SongService _songService;
        private readonly AlbumService _albumService;
        private readonly ArtistService _artistService;

        public UserController(IConfiguration configuration)
        {
            _userService = new UserService(new UserRepository(configuration));
            _songService = new SongService(new SongRepository(configuration));
            _albumService = new AlbumService(new AlbumRepository(configuration));
            _artistService = new ArtistService(new ArtistRepository(configuration));
        }

        private IActionResult RedirectToLoginIfNotLoggedIn()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login");
            return null!;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var user = _userService.Login(email, password);
                if (user == null)
                {
                    ViewBag.Error = "Invalid email or password.";
                    return View();
                }
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password, string confirmPassword)
        {
            try
            {
                _userService.Register(email, password, confirmPassword);
                ViewBag.Success = "Your account has been created successfully. You can now log in.";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult FavouriteSongs()
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                var favorites = _userService.GetFavorites(userId);
                var songs = _songService.GetSongs()
                    .Where(s => favorites!.FavoriteSongIds.Contains(s.Id))
                    .ToList();
                ViewBag.Songs = songs;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving your favourite songs.";
                return View();
            }
        }

        public IActionResult FavouriteAlbums()
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                var favorites = _userService.GetFavorites(userId);
                var albums = _albumService.GetAll()
                    .Where(a => favorites!.FavoriteAlbumIds.Contains(a.Id))
                    .ToList();
                ViewBag.Albums = albums;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving your favourite albums.";
                return View();
            }
        }

        public IActionResult FavouriteArtists()
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                var favorites = _userService.GetFavorites(userId);
                var artists = _artistService.GetArtists()
                    .Where(a => favorites!.FavoriteArtistIds.Contains(a.Id))
                    .ToList();
                ViewBag.Artists = artists;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving your favourite artists.";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddFavouriteSong(int songId)
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                _userService.AddFavoriteSong(userId, songId);
                return RedirectToAction("FavouriteSongs");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while adding the song to favourites.";
                return View("FavouriteSongs");
            }
        }

        [HttpPost]
        public IActionResult RemoveFavouriteSong(int songId)
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                _userService.RemoveFavoriteSong(userId, songId);
                return RedirectToAction("FavouriteSongs");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while removing the song from favourites.";
                return View("FavouriteSongs");
            }
        }

        [HttpPost]
        public IActionResult AddFavouriteAlbum(int albumId)
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                _userService.AddFavoriteAlbum(userId, albumId);
                return RedirectToAction("FavouriteAlbums");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while adding the album to favourites.";
                return View("FavouriteAlbums");
            }
        }

        [HttpPost]
        public IActionResult RemoveFavouriteAlbum(int albumId)
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                _userService.RemoveFavoriteAlbum(userId, albumId);
                return RedirectToAction("FavouriteAlbums");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while removing the album from favourites.";
                return View("FavouriteAlbums");
            }
        }

        [HttpPost]
        public IActionResult AddFavouriteArtist(int artistId)
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                _userService.AddFavoriteArtist(userId, artistId);
                return RedirectToAction("FavouriteArtists");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while adding the artist to favourites.";
                return View("FavouriteArtists");
            }
        }

        [HttpPost]
        public IActionResult RemoveFavouriteArtist(int artistId)
        {
            var redirect = RedirectToLoginIfNotLoggedIn();
            if (redirect != null) return redirect;

            try
            {
                int userId = HttpContext.Session.GetInt32("UserId")!.Value;
                _userService.RemoveFavoriteArtist(userId, artistId);
                return RedirectToAction("FavouriteArtists");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while removing the artist from favourites.";
                return View("FavouriteArtists");
            }
        }
    }
}