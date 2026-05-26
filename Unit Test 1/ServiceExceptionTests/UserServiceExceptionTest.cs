using serviceLibary.Services;
using Unit_Test_1.FakeRepositoriesExceptions;

namespace Unit_Test_1.ServiceExceptionTests
{
    [TestClass]
    public class UserServiceExceptionTest
    {
        [TestMethod]
        public void Register_ThrowsException_WhenPasswordTooShort()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.Register("test@test.com", "abc", "abc");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Password must be at least 8 characters long.", ex.Message);
            }
        }

        [TestMethod]
        public void Register_ThrowsException_WhenPasswordsDoNotMatch()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.Register("test@test.com", "password123", "password456");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Passwords do not match.", ex.Message);
            }
        }

        [TestMethod]
        public void Register_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.Register("test@test.com", "password123", "password123");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while registering.", ex.Message);
            }
        }

        [TestMethod]
        public void GetFavorites_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.GetFavorites(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void Login_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.Login("test@test.com", "password123");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while logging in.", ex.Message);
            }
        }

        [TestMethod]
        public void AddFavoriteSong_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.AddFavoriteSong(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the song to favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void AddFavoriteAlbum_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.AddFavoriteAlbum(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the album to favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void AddFavoriteArtist_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.AddFavoriteArtist(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the artist to favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void RemoveFavoriteSong_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.RemoveFavoriteSong(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while removing the song from favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void RemoveFavoriteAlbum_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.RemoveFavoriteAlbum(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while removing the album from favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void RemoveFavoriteArtist_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new UserService(new FakeRepositoryUserExceptions());

            // Act
            try
            {
                service.RemoveFavoriteArtist(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while removing the artist from favorites.", ex.Message);
            }
        }
    }
}