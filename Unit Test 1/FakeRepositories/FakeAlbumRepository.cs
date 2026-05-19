using DAL.DTO;
using Interfaces.Interfaces;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeAlbumRepository : IAlbumRepository
    {
        public List<AlbumDTO> GetAll() => new List<AlbumDTO>
        {
            new AlbumDTO(1, "Midnights", DateTime.MinValue, "Taylor Swift", 0, new()),
            new AlbumDTO(2, "Abbey Road", DateTime.MinValue, "The Beatles", 0, new())
        };
        public AlbumDTO? GetById(int id)
        {
            if (id == 1)
                return new AlbumDTO(1, "Midnights", DateTime.MinValue, "Taylor Swift", 0, new());
            return null;
        }
        public List<AlbumDTO> Search(string query) => new List<AlbumDTO>
        {
            new AlbumDTO(1, "Midnights", DateTime.MinValue, "Taylor Swift", 0, new())
        };
        public void AddFavorite(int userId, int albumId) { }
        public void RemoveFavorite(int userId, int albumId) { }
    }
}