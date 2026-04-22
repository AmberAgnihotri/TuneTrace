using DAL.DTOs;
using DAL.Repositories;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeAlbumRepository : IAlbumRepository
    {
        public List<AlbumDto> GetAll() => new List<AlbumDto>
        {
            new AlbumDto { Id = 1, Title = "Midnights", Artist = "Taylor Swift", Songs = new() },
            new AlbumDto { Id = 2, Title = "Abbey Road", Artist = "The Beatles", Songs = new() }
        };

        public AlbumDto? GetById(int id)
        {
            if (id == 1)
                return new AlbumDto { Id = 1, Title = "Midnights", Artist = "Taylor Swift", Songs = new() };
            return null;
        }

        public List<AlbumDto> Search(string query) => new List<AlbumDto>
        {
            new AlbumDto { Id = 1, Title = "Midnights", Artist = "Taylor Swift", Songs = new() }
        };

        public void AddFavorite(int userId, int albumId) { }
        public void RemoveFavorite(int userId, int albumId) { }
    }
}