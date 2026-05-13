using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using serviceLibary.Services;
using TuneTrace.ViewModels;

namespace TuneTrace.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ArtistService _service;

        public ArtistController(IConfiguration configuration)
        {
            _service = new ArtistService(new ArtistRepository(configuration));
        }

        public IActionResult Index()
        {
            try
            {
                var artists = _service.GetArtists();
                var viewModels = artists.Select(a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography
                }).ToList();
                return View(viewModels);
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the artist.";
                return View(new ArtistViewModel());
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var artist = _service.GetArtistById(id);
                if (artist == null) return NotFound();

                var viewModel = new ArtistViewModel
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Biography = artist.Biography,
                    Albums = artist.Albums.Select(a => new AlbumViewModel
                    {
                        Id = a.Id,
                        Title = a.Title,
                        ReleaseDate = a.ReleaseDate
                    }).ToList(),
                    Songs = artist.Songs.Select(s => new SongViewModel
                    {
                        Id = s.Id,
                        Title = s.Title,
                        ReleaseDate = s.ReleaseDate,
                        Duration = s.Duration
                    }).ToList()
                };
                return View(viewModel);
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the artist.";
                return View(new ArtistViewModel());
            }
        }

        public IActionResult Search(string query)
        {
            try
            {
                var artists = _service.SearchArtists(query);
                var viewModels = artists.Select(a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography
                }).ToList();
                return View(viewModels);
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong while retrieving the artist.";
                return View(new ArtistViewModel());
            }
        }
    }
}