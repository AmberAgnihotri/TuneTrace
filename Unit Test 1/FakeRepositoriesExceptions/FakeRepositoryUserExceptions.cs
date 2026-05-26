using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositoriesExceptions
{
    public class FakeRepositoryUserExceptions : IUserRepository
    {
        public UserDTO? GetFavorites(int userId) =>
            throw new Exception("Something went wrong while retrieving the favorites.");

        public UserDTO? Login(string email, string password) =>
            throw new Exception("Something went wrong while logging in.");

        public void AddFavoriteSong(int userId, int songId) =>
            throw new Exception("Something went wrong while adding the song to favorites.");

        public void AddFavoriteAlbum(int userId, int albumId) =>
            throw new Exception("Something went wrong while adding the album to favorites.");

        public void AddFavoriteArtist(int userId, int artistId) =>
            throw new Exception("Something went wrong while adding the artist to favorites.");

        public void RemoveFavoriteSong(int userId, int songId) =>
            throw new Exception("Something went wrong while removing the song from favorites.");

        public void RemoveFavoriteAlbum(int userId, int albumId) =>
            throw new Exception("Something went wrong while removing the album from favorites.");

        public void RemoveFavoriteArtist(int userId, int artistId) =>
            throw new Exception("Something went wrong while removing the artist from favorites.");

        public void Register(string email, string password) =>
            throw new Exception("Something went wrong while registering.");
    }
}