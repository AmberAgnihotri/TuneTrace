using DAL.DTO;
using Interfaces.Interfaces;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeSongRepository : ISongRepository
    {
        public List<SongDTO> GetSongs() => new List<SongDTO>
        {
            new SongDTO(1, 1, "Lavender Haze", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero),
            new SongDTO(2, 1, "Anti-Hero", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero)
        };
        public SongDTO? GetSongById(int id)
        {
            if (id == 1)
                return new SongDTO(1, 1, "Lavender Haze", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero);
            return null;
        }
        public List<SongDTO> SearchSongs(string query) => new List<SongDTO>
        {
            new SongDTO(1, 1, "Lavender Haze", "Taylor Swift", "Midnights", new DateTime(2022, 10, 21), TimeSpan.Zero)
        };
        public void AddFavorite(int userId, int songId) { }
        public void RemoveFavorite(int userId, int songId) { }
        public void AddRating(int userId, int songId, int rating) { }
        public void AddReview(int userId, int songId, string review) { }
    }
}