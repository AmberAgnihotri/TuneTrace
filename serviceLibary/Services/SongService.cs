using Interfaces.Interfaces;
using ServiceLibrary.Models;
using DAL.DTO;

namespace ServiceLibrary.Services
{
    public class SongService
    {
        private readonly ISongRepository _songRepo;

        public SongService(ISongRepository songRepo)
        {
            _songRepo = songRepo;
        }

        public List<SongModel> GetSongs()
        {
            return _songRepo.GetSongs().Select(MapSong).ToList();
        }

        public SongModel? GetSongById(int id)
        {
            var s = _songRepo.GetSongById(id);
            if (s == null) return null;
            return MapSong(s);
        }

        public List<SongModel> SearchSongs(string query)
        {
            if (query.Length < 2)
                throw new Exception("Search term too short");
            return _songRepo.SearchSongs(query).Select(MapSong).ToList();
        }

        public void AddFavorite(int userId, int songId)
            => _songRepo.AddFavorite(userId, songId);

        public void RemoveFavorite(int userId, int songId)
            => _songRepo.RemoveFavorite(userId, songId);

        public void AddRating(int userId, int songId, int rating)
            => _songRepo.AddRating(userId, songId, rating);

        public void AddReview(int userId, int songId, string review)
            => _songRepo.AddReview(userId, songId, review);

        private SongModel MapSong(SongDTO s)
        {
            return new SongModel(
                s.Id,
                s.AlbumId,
                s.Title,
                s.Artist,
                s.Album,
                s.ReleaseDate,
                s.Duration
            );
        }
    }
}