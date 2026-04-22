using DAL.DTOs;
using DAL.Repositories;
using ServiceLibrary.Models;
using ServiceLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1
{
    [TestClass]
    public class ReviewServiceTest
    {
        private class FakeReviewRepository : IReviewRepository
        {
            public void AddReview(int userId, int songId, string review, int rating) { }
            public void AddAlbumReview(int userId, int albumId, string review, int rating) { }

            public List<ReviewDTO> GetReviewsBySong(int songId) => new List<ReviewDTO>
            {
                new ReviewDTO { Id = 1, UserId = 1, SongId = songId, Rating = 8, ReviewText = "Great song!" }
            };

            public List<ReviewDTO> GetReviewsByAlbum(int albumId) => new List<ReviewDTO>
            {
                new ReviewDTO { Id = 2, UserId = 1, AlbumId = albumId, Rating = 9, ReviewText = "Great album!" }
            };

            public List<ReviewDTO> GetAllReviews() => new List<ReviewDTO>
            {
                new ReviewDTO { Id = 1, UserId = 1, SongId = 1, Rating = 8, ReviewText = "Great song!", SongTitle = "Lavender Haze" },
                new ReviewDTO { Id = 2, UserId = 1, AlbumId = 1, Rating = 9, ReviewText = "Great album!", AlbumTitle = "Midnights" }
            };

            public bool HasSongReview(int userId, int songId) => true;
            public bool HasAlbumReview(int userId, int albumId) => true;
        }

        [TestMethod]
        public void AddReview_ValidRating_DoesNotThrow()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act & Assert
            service.AddReview(1, 1, "Great song!", 8);
        }

        [TestMethod]
        public void AddReview_InvalidRating_ThrowsException()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            bool exceptionThrown = false;
            try { service.AddReview(1, 1, "Great song!", 11); }
            catch (ArgumentException) { exceptionThrown = true; }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void AddReview_RatingTooLow_ThrowsException()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            bool exceptionThrown = false;
            try { service.AddReview(1, 1, "Great song!", 0); }
            catch (ArgumentException) { exceptionThrown = true; }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void AddAlbumReview_ValidRating_DoesNotThrow()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act & Assert
            service.AddAlbumReview(1, 1, "Great album!", 9);
        }

        [TestMethod]
        public void AddAlbumReview_InvalidRating_ThrowsException()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            bool exceptionThrown = false;
            try { service.AddAlbumReview(1, 1, "Great album!", 11); }
            catch (ArgumentException) { exceptionThrown = true; }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GetReviewsBySong_ReturnsReviews()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            var result = service.GetReviewsBySong(1);

            // Assert
            Assert.HasCount(1, result);
            Assert.AreEqual(8, result[0].Rating);
        }

        [TestMethod]
        public void GetReviewsByAlbum_ReturnsReviews()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            var result = service.GetReviewsByAlbum(1);

            // Assert
            Assert.HasCount(1, result);
            Assert.AreEqual(9, result[0].Rating);
        }

        [TestMethod]
        public void GetAllReviews_ReturnsAllReviews()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            var result = service.GetAllReviews();

            // Assert
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void HasSongReview_ReturnsTrue()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            var result = service.HasSongReview(1, 1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasAlbumReview_ReturnsTrue()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());

            // Act
            var result = service.HasAlbumReview(1, 1);

            // Assert
            Assert.IsTrue(result);
        }
    }
}