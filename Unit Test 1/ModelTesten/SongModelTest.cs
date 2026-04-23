using ServiceLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ModelTesten
{
    [TestClass]
    public class SongModelTest
    {
        [TestMethod]
        public void SongModel_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var albumId = 1;
            var title = "Lavender Haze";
            var artist = "Taylor Swift";
            var album = "Midnights";
            var releaseDate = new DateTime(2022, 10, 21);
            var duration = TimeSpan.Zero;

            // Act
            var song = new SongModel(id, albumId, title, artist, album, releaseDate, duration);

            // Assert
            Assert.AreEqual(id, song.Id);
            Assert.AreEqual(albumId, song.AlbumId);
            Assert.AreEqual(title, song.Title);
            Assert.AreEqual(artist, song.Artist);
            Assert.AreEqual(album, song.Album);
            Assert.AreEqual(releaseDate, song.ReleaseDate);
            Assert.AreEqual(duration, song.Duration);
        }
    }
}