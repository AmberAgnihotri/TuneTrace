using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TuneTrace.Models;
using TuneTrace.Repositories;
using Microsoft.Data.SqlClient;

namespace TuneTrace.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString = string.Empty;
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly SongRepository _songRepository;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
            _artistRepository = new ArtistRepository(configuration);
            _albumRepository = new AlbumRepository(configuration);
            _songRepository = new SongRepository(configuration);
        }

        public IActionResult Index()
        {
            ViewBag.Artists = _artistRepository.GetArtists();
            ViewBag.Albums = _albumRepository.GetAlbums();
            ViewBag.Songs = _songRepository.GetSongs();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestDB()
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                return Content(" Connection Succesful!");
            }
            catch (Exception ex)
            {
                return Content(" Wrong: " + ex.Message);
            }
        }
    }
}