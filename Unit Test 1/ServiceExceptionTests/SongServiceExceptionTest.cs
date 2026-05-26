using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositoriesExceptions;

namespace Unit_Test_1.ServiceExceptionTests
{
    [TestClass]
    public class SongServiceExceptionTest
    {
        [TestMethod]
        public void GetSongs_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.GetSongs();
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the songs.", ex.Message);
            }
        }

        [TestMethod]
        public void GetSongById_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.GetSongById(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the song.", ex.Message);
            }
        }

        [TestMethod]
        public void SearchSongs_ThrowsException_WhenSearchTermTooShort()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.SearchSongs("a");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Search term too short", ex.Message);
            }
        }

        [TestMethod]
        public void SearchSongs_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.SearchSongs("Taylor Swift");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while searching for songs.", ex.Message);
            }
        }

        [TestMethod]
        public void AddFavorite_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.AddFavorite(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the song to favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void RemoveFavorite_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.RemoveFavorite(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while removing the song from favorites.", ex.Message);
            }
        }

        [TestMethod]
        public void AddRating_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.AddRating(1, 1, 5);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the rating.", ex.Message);
            }
        }

        [TestMethod]
        public void AddReview_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new SongService(new FakeRepositorySongExceptions());

            // Act
            try
            {
                service.AddReview(1, 1, "Great song");
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the review.", ex.Message);
            }
        }
    }
}