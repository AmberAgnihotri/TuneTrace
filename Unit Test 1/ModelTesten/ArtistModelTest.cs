using serviceLibary.Models;
using ServiceLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ModelTesten
{
    [TestClass]
    public class ArtistModelTest
    {
        [TestMethod]
        public void ArtistModel_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var name = "Taylor Swift";
            var biography = "American singer-songwriter";
            var albums = new List<AlbumModel>();
            var songs = new List<SongModel>();

            // Act
            var artist = new ArtistModel(id, name, biography, albums, songs);

            // Assert
            Assert.AreEqual(id, artist.Id);
            Assert.AreEqual(name, artist.Name);
            Assert.AreEqual(biography, artist.Biography);
            Assert.IsNotNull(artist.Albums);
            Assert.IsNotNull(artist.Songs);
        }
    }
}