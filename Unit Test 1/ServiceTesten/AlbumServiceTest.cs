using DAL.Repositories;
using serviceLibary.Services;
using Unit_Test_1.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class AlbumServiceTest
    {
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