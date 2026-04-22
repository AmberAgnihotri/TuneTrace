using DAL.DTOs;
using DAL.Repositories;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeSongRepository : ISongRepository
    {
        public List<SongDto> GetSongs() => new List<SongDto>
        {
            new SongDto { Id = 1, Title = "Lavender Haze", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero },
            new SongDto { Id = 2, Title = "Anti-Hero", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero }
        };

        public SongDto? GetSongById(int id)
        {
            if (id == 1)
                return new SongDto { Id = 1, Title = "Lavender Haze", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero };
            return null;
        }

        public List<SongDto> SearchSongs(string query) => new List<SongDto>
        {
            new SongDto { Id = 1, Title = "Lavender Haze", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero }
        };

        public void AddFavorite(int userId, int songId) { }
        public void RemoveFavorite(int userId, int songId) { }
        public void AddRating(int userId, int songId, int rating) { }
        public void AddReview(int userId, int songId, string review) { }
    }
}