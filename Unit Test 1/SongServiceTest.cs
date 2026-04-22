using DAL.DTOs;
using DAL.Repositories;
using ServiceLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1
{
    [TestClass]
    public class SongServiceTest
    {
        private class FakeSongRepository : ISongRepository
        {
            public List<SongDto> GetSongs() => new List<SongDto>
            {
                new SongDto { Id = 1, Title = "Lavender Haze", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero },
                new SongDto { Id = 2, Title = "Anti-Hero", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero }
            };

            public SongDto? GetSongById(int id)
            {
                if (id == 1)
                    return new SongDto { Id = 1, Title = "Lavender Haze", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero };
                return null;
            }

            public List<SongDto> SearchSongs(string query) => new List<SongDto>
            {
                new SongDto { Id = 1, Title = "Lavender Haze", Artist = "Taylor Swift", Album = "Midnights", AlbumId = 1, ReleaseDate = new DateTime(2022, 10, 21), Duration = TimeSpan.Zero }
            };

            public void AddFavorite(int userId, int songId) { }
            public void RemoveFavorite(int userId, int songId) { }
            public void AddRating(int userId, int songId, int rating) { }
            public void AddReview(int userId, int songId, string review) { }
        }

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

            // Act
            bool exceptionThrown = false;
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