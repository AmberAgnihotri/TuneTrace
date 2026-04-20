
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using serviceLibary.Services;
using TuneTrace.ViewModels;
using ServiceLibrary.Services;


namespace TuneTrace.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly SongService _songService;
        private readonly AlbumService _albumService;
        private readonly ArtistService _artistService;

        public UserController(UserService userService, SongService songService, AlbumService albumService, ArtistService artistService)
        {
            _userService = userService;
            _songService = songService;
            _albumService = albumService;
            _artistService = artistService;
        }

        public IActionResult FavouriteSongs()
        {
            var favorites = _userService.GetFavorites(1);
            var songs = _songService.GetSongs()
                .Where(s => favorites!.FavoriteSongIds.Contains(s.Id))
                .ToList();
            ViewBag.Songs = songs;
            return View();
        }

        public IActionResult FavouriteAlbums()
        {
            var favorites = _userService.GetFavorites(1);
            var albums = _albumService.GetAll()
                .Where(a => favorites!.FavoriteAlbumIds.Contains(a.Id))
                .ToList();
            ViewBag.Albums = albums;
            return View();
        }

        public IActionResult FavouriteArtists()
        {
            var favorites = _userService.GetFavorites(1);
            var artists = _artistService.GetArtists()
                .Where(a => favorites!.FavoriteArtistIds.Contains(a.Id))
                .ToList();
            ViewBag.Artists = artists;
            return View();
        }

        [HttpPost]
        public IActionResult AddFavouriteSong(int songId)
        {
            _userService.AddFavoriteSong(1, songId);
            return RedirectToAction("FavouriteSongs");
        }

        [HttpPost]
        public IActionResult RemoveFavouriteSong(int songId)
        {
            _userService.RemoveFavoriteSong(1, songId);
            return RedirectToAction("FavouriteSongs");
        }

        [HttpPost]
        public IActionResult AddFavouriteAlbum(int albumId)
        {
            _userService.AddFavoriteAlbum(1, albumId);
            return RedirectToAction("FavouriteAlbums");
        }

        [HttpPost]
        public IActionResult RemoveFavouriteAlbum(int albumId)
        {
            _userService.RemoveFavoriteAlbum(1, albumId);
            return RedirectToAction("FavouriteAlbums");
        }

        [HttpPost]
        public IActionResult AddFavouriteArtist(int artistId)
        {
            _userService.AddFavoriteArtist(1, artistId);
            return RedirectToAction("FavouriteArtists");
        }

        [HttpPost]
        public IActionResult RemoveFavouriteArtist(int artistId)
        {
            _userService.RemoveFavoriteArtist(1, artistId);
            return RedirectToAction("FavouriteArtists");
        }
    }
}