using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using serviceLibary.Services;
using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositories;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class UserServiceTest
    {
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
    }
}