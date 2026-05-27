using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositoriesExceptions
{
    public class FakeRepositoryAlbumExceptions : IAlbumRepository
    {
        public List<AlbumDTO> GetAll() =>
            throw new Exception("Something went wrong with fetching albums");

        public AlbumDTO? GetById(int id) =>
            throw new Exception("Something went wrong with fetching the album");

        public List<AlbumDTO> Search(string query) =>
            throw new Exception("Something went wrong with searching albums");

        public void AddFavorite(int userId, int albumId) =>
            throw new Exception("Something went wrong with adding to favourites");

        public void RemoveFavorite(int userId, int albumId) =>
            throw new Exception("Something went wrong with removing from favourites");
    }
}
