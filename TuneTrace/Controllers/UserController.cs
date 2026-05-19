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

        public IActionResult FavouriteSongs()
        {
            try
            {
                var favorites = _userService.GetFavorites(1);
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
            try
            {
                var favorites = _userService.GetFavorites(1);
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
            try
            {
                var favorites = _userService.GetFavorites(1);
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
            try
            {
                _userService.AddFavoriteSong(1, songId);
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
            try
            {
                _userService.RemoveFavoriteSong(1, songId);
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
            try
            {
                _userService.AddFavoriteAlbum(1, albumId);
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
            try
            {
                _userService.RemoveFavoriteAlbum(1, albumId);
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
            try
            {
                _userService.AddFavoriteArtist(1, artistId);
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
            try
            {
                _userService.RemoveFavoriteArtist(1, artistId);
                return RedirectToAction("FavouriteArtists");
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while removing the artist from favourites.";
                return View("FavouriteArtists");
            }
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
    }
}