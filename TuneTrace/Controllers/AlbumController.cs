using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using serviceLibary.Services;
using TuneTrace.ViewModels;

namespace TuneTrace.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumService _service;

        public AlbumController(IConfiguration configuration)
        {
            _service = new AlbumService(new AlbumRepository(configuration));
        }

        public IActionResult Index()
        {
            try
            {
                var albums = _service.GetAll().Select(a => new AlbumViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ArtistName = a.Artist,
                    ReleaseDate = a.ReleaseDate
                }).ToList();
                ViewBag.Albums = albums;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the album.";
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var album = _service.GetById(id);
                if (album == null) return NotFound();

                var viewModel = new AlbumViewModel
                {
                    Id = album.Id,
                    Title = album.Title,
                    ArtistName = album.Artist,
                    ReleaseDate = album.ReleaseDate,
                    Songs = album.Songs.Select(s => new SongViewModel
                    {
                        Id = s.Id,
                        Title = s.Title,
                        Duration = s.Duration,
                        ReleaseDate = s.ReleaseDate,
                        Artist = album.Artist,
                        Album = album.Title
                    }).ToList()
                };

                ViewBag.Album = viewModel;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the album.";
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

                var albums = _service.Search(query).Select(a => new AlbumViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ArtistName = a.Artist,
                    ReleaseDate = a.ReleaseDate
                }).ToList();

                ViewBag.Albums = albums;
                ViewBag.Query = query;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while searching the album.";
                return View();
            }
        }
    }
}