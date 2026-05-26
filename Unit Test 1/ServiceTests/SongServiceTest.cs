using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositories;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class SongServiceTest
    {
        [TestMethod]
        public void GetSongs_ReturnsAllSongs()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act
            var result = service.GetSongs();
            // Assert
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void GetSongById_ReturnsCorrectSong()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act
            var result = service.GetSongById(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lavender Haze", result.Title);
            Assert.AreEqual("Taylor Swift", result.Artist);
        }

        [TestMethod]
        public void GetSongById_ReturnsNull_WhenNotFound()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act
            var result = service.GetSongById(99);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchSongs_ReturnsResults()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act
            var result = service.SearchSongs("Lavender");
            // Assert
            Assert.HasCount(1, result);
            Assert.AreEqual("Lavender Haze", result[0].Title);
        }

        [TestMethod]
        public void SearchSongs_ShortQuery_ThrowsException()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            bool exceptionThrown = false;
            // Act
            try { service.SearchSongs("a"); }
            catch (Exception) { exceptionThrown = true; }
            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void AddFavorite_DoesNotThrow()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act & Assert
            service.AddFavorite(1, 1);
        }

        [TestMethod]
        public void RemoveFavorite_DoesNotThrow()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act & Assert
            service.RemoveFavorite(1, 1);
        }

        [TestMethod]
        public void AddRating_DoesNotThrow()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act & Assert
            service.AddRating(1, 1, 8);
        }

        [TestMethod]
        public void AddReview_DoesNotThrow()
        {
            // Arrange
            var service = new SongService(new FakeSongRepository());
            // Act & Assert
            service.AddReview(1, 1, "Great song!");
        }
    }
}