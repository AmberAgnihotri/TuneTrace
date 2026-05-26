using serviceLibary.Services;
using Unit_Test_1.FakeRepositoriesExceptions;

namespace Unit_Test_1.ServiceExceptionTests
{
    [TestClass]
    public class ArtistServiceExceptionTest
    {
        [TestMethod]
        public void GetArtists_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ArtistService(new FakeRepositoryArtistExceptions());

            // Act
            try
            {
                service.GetArtists();
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the artists.", ex.Message);
            }
        }

        [TestMethod]
        public void GetArtistById_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ArtistService(new FakeRepositoryArtistExceptions());

            // Act
            try
            {
                service.GetArtistById(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the artist.", ex.Message);
            }
        }

        [TestMethod]
        public void SearchArtists_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ArtistService(new FakeRepositoryArtistExceptions());

            // Act
            try
            {
                service.SearchArtists("Taylor Swift");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while searching for artists.", ex.Message);
            }
        }

        [TestMethod]
        public void AddFavoriteArtist_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ArtistService(new FakeRepositoryArtistExceptions());

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
        public void RemoveFavoriteArtist_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ArtistService(new FakeRepositoryArtistExceptions());

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