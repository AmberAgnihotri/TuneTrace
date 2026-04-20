using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using serviceLibary.Services;
using ServiceLibrary.Services;
using TuneTrace.ViewModels;

namespace TuneTrace.Controllers
{
    public class DiscoverController : Controller
    {
        private readonly SongService _songService;
        private readonly AlbumService _albumService;
        private readonly ArtistService _artistService;
        private readonly UserService _userService;

        public DiscoverController(SongService songService, AlbumService albumService, ArtistService artistService, UserService userService)
        {
            _songService = songService;
            _albumService = albumService;
            _artistService = artistService;
            _userService = userService;
        }

        public IActionResult Index(string query, string filter = "all")
        {
            ViewBag.Query = query;
            ViewBag.Filter = filter;
            ViewBag.RecentSearches = _userService.GetRecentSearches(1);

            if (query == null || query.Length < 2)
            {
                if (query != null)
                    ViewBag.Error = "Search term too short — please enter a minimum of 2 characters.";
                return View();
            }

            _userService.SaveSearch(1, query);

            if (filter == "all" || filter == "songs")
                ViewBag.Songs = _songService.SearchSongs(query).Select(s => new SongViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Artist = s.Artist,
                    Album = s.Album,
                    ReleaseDate = s.ReleaseDate,
                    Duration = s.Duration
                }).ToList();

            if (filter == "all" || filter == "albums")
                ViewBag.Albums = _albumService.Search(query).Select(a => new AlbumViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ArtistName = a.Artist,
                    ReleaseDate = a.ReleaseDate
                }).ToList();

            if (filter == "all" || filter == "artists")
                ViewBag.Artists = _artistService.SearchArtists(query).Select(a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography
                }).ToList();

            return View();
        }
    }
}