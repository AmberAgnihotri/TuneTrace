using DAL.DTOs;
using DAL.Repositories;
using serviceLibary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1
{
    [TestClass]
    public class AlbumServiceTest
    {
        private class FakeAlbumRepository : IAlbumRepository
        {
            public List<AlbumDto> GetAll() => new List<AlbumDto>
            {
                new AlbumDto { Id = 1, Title = "Midnights", Artist = "Taylor Swift" },
                new AlbumDto { Id = 2, Title = "Abbey Road", Artist = "The Beatles" }
            };

            public AlbumDto? GetById(int id)
            {
                if (id == 1)
                    return new AlbumDto { Id = 1, Title = "Midnights", Artist = "Taylor Swift" };
                return null;
            }

            public List<AlbumDto> Search(string query) => new List<AlbumDto>
            {
                new AlbumDto { Id = 1, Title = "Midnights", Artist = "Taylor Swift" }
            };

            public void AddFavorite(int userId, int albumId) { }
            public void RemoveFavorite(int userId, int albumId) { }
        }

        [TestMethod]
        public void GetAll_ReturnsAllAlbums()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act
            var result = service.GetAll();

            // Assert
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void GetById_ReturnsCorrectAlbum()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act
            var result = service.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Midnights", result.Title);
            Assert.AreEqual("Taylor Swift", result.Artist);
        }

        [TestMethod]
        public void GetById_ReturnsNull_WhenNotFound()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act
            var result = service.GetById(99);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Search_ReturnsResults()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act
            var result = service.Search("Midnights");

            // Assert
            Assert.HasCount(1, result);
            Assert.AreEqual("Midnights", result[0].Title);
        }

        [TestMethod]
        public void GetAll_MapsCorrectly()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act
            var result = service.GetAll();

            // Assert
            Assert.AreEqual("Midnights", result[0].Title);
            Assert.AreEqual("Abbey Road", result[1].Title);
        }

        [TestMethod]
        public void AddFavorite_DoesNotThrow()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act & Assert
            service.AddFavorite(1, 1);
        }

        [TestMethod]
        public void RemoveFavorite_DoesNotThrow()
        {
            // Arrange
            var service = new AlbumService(new FakeAlbumRepository());

            // Act & Assert
            service.RemoveFavorite(1, 1);
        }
    }
}