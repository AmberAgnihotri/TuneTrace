using DAL.Repositories;
using serviceLibary.Services;
using Unit_Test_1.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class ArtistServiceTest
    {
        [TestMethod]
        public void GetArtists_ReturnsAllArtists()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act
            var result = service.GetArtists();
            // Assert
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void GetArtistById_ReturnsCorrectArtist()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act
            var result = service.GetArtistById(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Taylor Swift", result.Name);
        }

        [TestMethod]
        public void GetArtistById_ReturnsNull_WhenNotFound()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act
            var result = service.GetArtistById(99);
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchArtists_ReturnsResults()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act
            var result = service.SearchArtists("Taylor");
            // Assert
            Assert.HasCount(1, result);
            Assert.AreEqual("Taylor Swift", result[0].Name);
        }

        [TestMethod]
        public void GetArtists_MapsNameCorrectly()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act
            var result = service.GetArtists();
            // Assert
            Assert.AreEqual("Taylor Swift", result[0].Name);
            Assert.AreEqual("The Beatles", result[1].Name);
        }

        [TestMethod]
        public void AddFavoriteArtist_DoesNotThrow()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act & Assert
            service.AddFavoriteArtist(1, 1);
        }

        [TestMethod]
        public void RemoveFavoriteArtist_DoesNotThrow()
        {
            // Arrange
            var service = new ArtistService(new FakeArtistRepository());
            // Act & Assert
            service.RemoveFavoriteArtist(1, 1);
        }
    }
}