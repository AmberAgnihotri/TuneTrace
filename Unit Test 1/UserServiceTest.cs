using DAL.DTOs;
using DAL.Repositories;
using serviceLibary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1
{
    [TestClass]
    public class UserServiceTest
    {
        private class FakeUserRepository : IUserRepository
        {
            public UserDTO? GetFavorites(int userId)
            {
                if (userId == 1)
                    return new UserDTO
                    {
                        Id = 1,
                        FavoriteSongs = new List<int> { 1, 2 },
                        FavoriteAlbums = new List<int> { 1 },
                        FavoriteArtists = new List<int> { 1 }
                    };
                return null;
            }

            public bool SaveFavoriteSong(int userId, int songId) => true;
            public void AddFavoriteSong(int userId, int songId) { }
            public void RemoveFavoriteSong(int userId, int songId) { }
            public void AddFavoriteAlbum(int userId, int albumId) { }
            public void RemoveFavoriteAlbum(int userId, int albumId) { }
            public void AddFavoriteArtist(int userId, int artistId) { }
            public void RemoveFavoriteArtist(int userId, int artistId) { }
            public List<string> GetRecentSearches(int userId) => new List<string> { "Taylor Swift", "Midnights" };
            public void SaveSearch(int userId, string searchTerm) { }
        }

        [TestMethod]
        public void GetFavorites_ReturnsCorrectFavorites()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act
            var result = service.GetFavorites(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.HasCount(2, result.FavoriteSongIds);
            Assert.HasCount(1, result.FavoriteAlbumIds);
            Assert.HasCount(1, result.FavoriteArtistIds);
        }

        [TestMethod]
        public void GetFavorites_ReturnsNull_WhenUserNotFound()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act
            var result = service.GetFavorites(99);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddFavoriteSong_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.AddFavoriteSong(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteSong_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.RemoveFavoriteSong(1, 1);
        }

        [TestMethod]
        public void AddFavoriteAlbum_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.AddFavoriteAlbum(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteAlbum_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.RemoveFavoriteAlbum(1, 1);
        }

        [TestMethod]
        public void AddFavoriteArtist_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.AddFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteArtist_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.RemoveFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void GetRecentSearches_ReturnsSearches()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act
            var result = service.GetRecentSearches(1);

            // Assert
            Assert.HasCount(2, result);
            Assert.AreEqual("Taylor Swift", result[0]);
        }

        [TestMethod]
        public void SaveSearch_DoesNotThrow()
        {
            // Arrange
            var service = new UserService(new FakeUserRepository());

            // Act & Assert
            service.SaveSearch(1, "Taylor Swift");
        }
    }
}