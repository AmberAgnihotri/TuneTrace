using DAL.Repositories;
using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_1.ServiceTesten
{
    [TestClass]
    public class ReviewServiceTest
    {
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
            bool exceptionThrown = false;
            // Act
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
            bool exceptionThrown = false;
            // Act
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
            bool exceptionThrown = false;
            // Act
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

        [TestMethod]
        public void GetReviewsByUser_ReturnsReviews()
        {
            // Arrange
            var service = new ReviewService(new FakeReviewRepository());
            // Act
            var result = service.GetReviewsByUser(1);
            // Assert
            Assert.HasCount(2, result);
            Assert.AreEqual(1, result[0].UserId);
        }
    }
}