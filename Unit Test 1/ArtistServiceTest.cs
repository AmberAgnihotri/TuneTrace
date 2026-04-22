using DAL.DTOs;
using DAL.Repositories;
using serviceLibary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1
{
    [TestClass]
    public class ArtistServiceTest
    {
        private class FakeArtistRepository : IArtistRepository
        {
            public List<ArtistDTO> GetArtists() => new List<ArtistDTO>
            {
                new ArtistDTO { Id = 1, Name = "Taylor Swift", Biography = "American singer-songwriter" },
                new ArtistDTO { Id = 2, Name = "The Beatles", Biography = "English rock band" }
            };

            public ArtistDTO? GetArtistById(int id)
            {
                if (id == 1)
                    return new ArtistDTO { Id = 1, Name = "Taylor Swift", Biography = "American singer-songwriter" };
                return null;
            }

            public List<ArtistDTO> SearchArtists(string query) => new List<ArtistDTO>
            {
                new ArtistDTO { Id = 1, Name = "Taylor Swift", Biography = "American singer-songwriter" }
            };

            public void AddFavoriteArtist(int userId, int artistId) { }
            public void RemoveFavoriteArtist(int userId, int artistId) { }
        }

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