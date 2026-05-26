using serviceLibary.Services;
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
            var service = new UserService(new FakeUserRepository());
            service.AddFavoriteSong(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteSong_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.RemoveFavoriteSong(1, 1);
        }

        [TestMethod]
        public void AddFavoriteAlbum_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.AddFavoriteAlbum(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteAlbum_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.RemoveFavoriteAlbum(1, 1);
        }

        [TestMethod]
        public void AddFavoriteArtist_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.AddFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteArtist_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.RemoveFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void Register_DoesNotThrow()
        {
            var service = new UserService(new FakeUserRepository());
            service.Register("test@test.com", "welkom123", "welkom123");
        }

        [TestMethod]
        public void Register_ThrowsException_WhenPasswordTooShort()
        {
            var service = new UserService(new FakeUserRepository());
            try
            {
                service.Register("test@test.com", "kort", "kort");
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Password must be at least 8 characters long.", ex.Message);
            }
        }

        [TestMethod]
        public void Register_ThrowsException_WhenPasswordsDoNotMatch()
        {
            var service = new UserService(new FakeUserRepository());
            try
            {
                service.Register("test@test.com", "welkom123", "anders123");
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Passwords do not match.", ex.Message);
            }
        }

        [TestMethod]
        public void Login_ReturnsUser_WhenCredentialsAreCorrect()
        {
            var service = new UserService(new FakeUserRepository());
            var result = service.Login("test@test.com", "welkom123");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("test@test.com", result.Email);
        }

        [TestMethod]
        public void Login_ReturnsNull_WhenCredentialsAreIncorrect()
        {
            var service = new UserService(new FakeUserRepository());
            var result = service.Login("test@test.com", "wrongpassword");
            Assert.IsNull(result);
        }
    }
}

