using serviceLibary.Services;
using Unit_Test_1.FakeRepositoriesExceptions;

namespace Unit_Test_1.ServiceExceptionTests
{
    [TestClass]
    public class AlbumServiceExceptionTest
    {
        [TestMethod]
        public void GetAll_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new AlbumService(new FakeRepositoryAlbumExceptions());

            // Act
            try
            {
                service.GetAll();
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong with fetching albums", ex.Message);
            }
        }

        [TestMethod]
        public void GetById_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new AlbumService(new FakeRepositoryAlbumExceptions());

            // Act
            try
            {
                service.GetById(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong with fetching the album", ex.Message);
            }
        }

        [TestMethod]
        public void Search_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new AlbumService(new FakeRepositoryAlbumExceptions());

            // Act
            try
            {
                service.Search("Midnights");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong with searching albums", ex.Message);
            }
        }

        [TestMethod]
        public void AddFavorite_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new AlbumService(new FakeRepositoryAlbumExceptions());

            // Act
            try
            {
                service.AddFavorite(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong with adding to favourites", ex.Message);
            }
        }

        [TestMethod]
        public void RemoveFavorite_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new AlbumService(new FakeRepositoryAlbumExceptions());

            // Act
            try
            {
                service.RemoveFavorite(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong with removing from favourites", ex.Message);
            }
        }
    }
}