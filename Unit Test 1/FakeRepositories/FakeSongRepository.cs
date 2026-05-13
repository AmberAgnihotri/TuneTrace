using DAL.DTO;
using Interfaces.Interfaces;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeSongRepository : ISongRepository
    {
        public List<SongDto> GetSongs() => new List<SongDto>
        {
            new SongDto(1, 1, "Lavender Haze", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero),
            new SongDto(2, 1, "Anti-Hero", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero)
        };
        public SongDto? GetSongById(int id)
        {
            if (id == 1)
                return new SongDto(1, 1, "Lavender Haze", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero);
            return null;
        }
        public List<SongDto> SearchSongs(string query) => new List<SongDto>
        {
            new SongDto(1, 1, "Lavender Haze", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero)
        };
        public void AddFavorite(int userId, int songId) { }
        public void RemoveFavorite(int userId, int songId) { }
        public void AddRating(int userId, int songId, int rating) { }
        public void AddReview(int userId, int songId, string review) { }
    }
}