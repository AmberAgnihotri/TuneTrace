using DAL.DTO;
using Interfaces.Interfaces;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeAlbumRepository : IAlbumRepository
    {
        public List<AlbumDto> GetAll() => new List<AlbumDto>
        {
            new AlbumDto(1, "Midnights", DateTime.MinValue, "Taylor Swift", 0, new()),
            new AlbumDto(2, "Abbey Road", DateTime.MinValue, "The Beatles", 0, new())
        };
        public AlbumDto? GetById(int id)
        {
            if (id == 1)
                return new AlbumDto(1, "Midnights", DateTime.MinValue, "Taylor Swift", 0, new());
            return null;
        }
        public List<AlbumDto> Search(string query) => new List<AlbumDto>
        {
            new AlbumDto(1, "Midnights", DateTime.MinValue, "Taylor Swift", 0, new())
        };
        public void AddFavorite(int userId, int albumId) { }
        public void RemoveFavorite(int userId, int albumId) { }
    }
}