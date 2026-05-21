using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        public UserDTO? GetFavorites(int userId)
        {
            if (userId == 1)
                return new UserDTO(1, "", "", new List<int> { 1, 2 }, new List<int> { 1 }, new List<int> { 1 });
            return null;
        }

        public UserDTO? Login(string email, string password)
        {
            if (email == "test@test.com" && password == "welkom123")
                return new UserDTO(1, email, password, new List<int>(), new List<int>(), new List<int>());
            return null;
        }

        public void AddFavoriteSong(int userId, int songId) { }
        public void RemoveFavoriteSong(int userId, int songId) { }
        public void AddFavoriteAlbum(int userId, int albumId) { }
        public void RemoveFavoriteAlbum(int userId, int albumId) { }
        public void AddFavoriteArtist(int userId, int artistId) { }
        public void RemoveFavoriteArtist(int userId, int artistId) { }
        public void Register(string email, string password) { }
    }
}