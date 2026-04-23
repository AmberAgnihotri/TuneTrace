using ServiceLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ModelTesten
{
    [TestClass]
    public class ReviewModelTest
    {
        [TestMethod]
        public void ReviewModel_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var userId = 1;
            var albumId = 1;
            var songId = 1;
            var rating = 8;
            var reviewText = "Great song!";
            var songTitle = "Lavender Haze";
            var albumTitle = "Midnights";

            // Act
            var review = new ReviewModel(id, userId, albumId, songId, rating, reviewText, songTitle, albumTitle);

            // Assert
            Assert.AreEqual(id, review.Id);
            Assert.AreEqual(userId, review.UserId);
            Assert.AreEqual(albumId, review.AlbumId);
            Assert.AreEqual(songId, review.SongId);
            Assert.AreEqual(rating, review.Rating);
            Assert.AreEqual(reviewText, review.ReviewText);
            Assert.AreEqual(songTitle, review.SongTitle);
            Assert.AreEqual(albumTitle, review.AlbumTitle);
        }
    }
}