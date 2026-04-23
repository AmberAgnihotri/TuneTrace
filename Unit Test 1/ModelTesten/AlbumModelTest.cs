using serviceLibary.Models;
using ServiceLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ModelTesten
{
    [TestClass]
    public class AlbumModelTest
    {
        [TestMethod]
        public void AlbumModel_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var title = "Midnights";
            var artist = "Taylor Swift";
            var artistId = 1;
            var releaseDate = new DateTime(2022, 10, 21);
            var songs = new List<SongModel>();

            // Act
            var album = new AlbumModel(id, title, artist, artistId, releaseDate, songs);

            // Assert
            Assert.AreEqual(id, album.Id);
            Assert.AreEqual(title, album.Title);
            Assert.AreEqual(artist, album.Artist);
            Assert.AreEqual(artistId, album.ArtistId);
            Assert.AreEqual(releaseDate, album.ReleaseDate);
            Assert.IsNotNull(album.Songs);
        }
    }
}