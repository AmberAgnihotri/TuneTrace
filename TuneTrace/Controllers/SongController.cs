using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Services;
using TuneTrace.ViewModels;

namespace TuneTrace.Controllers
{
    public class SongController : Controller
    {
        private readonly SongService _service;

        public SongController(IConfiguration configuration)
        {
            _service = new SongService(new SongRepository(configuration));
        }

        public IActionResult Index()
        {
            try
            {
                var songs = _service.GetSongs().Select(s => new SongViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Artist = s.Artist,
                    Album = s.Album,
                    ReleaseDate = s.ReleaseDate,
                    Duration = s.Duration
                }).ToList();
                ViewBag.Songs = songs;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the songs.";
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var song = _service.GetSongById(id);
                if (song == null) return NotFound();

                var viewModel = new SongViewModel
                {
                    Id = song.Id,
                    Title = song.Title,
                    Artist = song.Artist,
                    Album = song.Album,
                    ReleaseDate = song.ReleaseDate,
                    Duration = song.Duration
                };
                ViewBag.Song = viewModel;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the song.";
                return View();
            }
        }

        public IActionResult Search(string query)
        {
            try
            {
                if (query == null || query.Length < 2)
                {
                    ViewBag.Error = "Search query must be at least 2 characters.";
                    return View();
                }

                var songs = _service.SearchSongs(query).Select(s => new SongViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Artist = s.Artist,
                    Album = s.Album,
                    ReleaseDate = s.ReleaseDate,
                    Duration = s.Duration
                }).ToList();
                ViewBag.Songs = songs;
                ViewBag.Query = query;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while searching for songs.";
                return View();
            }
        }
    }
}