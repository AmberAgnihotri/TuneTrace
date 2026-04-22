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
            var service = new ReviewService(new FakeReviewRepository());
            service.AddReview(1, 1, "Great song!", 8);
        }

        [TestMethod]
        public void AddReview_InvalidRating_ThrowsException()
        {
            var service = new ReviewService(new FakeReviewRepository());
            bool exceptionThrown = false;
            try { service.AddReview(1, 1, "Great song!", 11); }
            catch (ArgumentException) { exceptionThrown = true; }
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void AddReview_RatingTooLow_ThrowsException()
        {
            var service = new ReviewService(new FakeReviewRepository());
            bool exceptionThrown = false;
            try { service.AddReview(1, 1, "Great song!", 0); }
            catch (ArgumentException) { exceptionThrown = true; }
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void AddAlbumReview_ValidRating_DoesNotThrow()
        {
            var service = new ReviewService(new FakeReviewRepository());
            service.AddAlbumReview(1, 1, "Great album!", 9);
        }

        [TestMethod]
        public void AddAlbumReview_InvalidRating_ThrowsException()
        {
            var service = new ReviewService(new FakeReviewRepository());
            bool exceptionThrown = false;
            try { service.AddAlbumReview(1, 1, "Great album!", 11); }
            catch (ArgumentException) { exceptionThrown = true; }
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void GetReviewsBySong_ReturnsReviews()
        {
            var service = new ReviewService(new FakeReviewRepository());
            var result = service.GetReviewsBySong(1);
            Assert.HasCount(1, result);
            Assert.AreEqual(8, result[0].Rating);
        }

        [TestMethod]
        public void GetReviewsByAlbum_ReturnsReviews()
        {
            var service = new ReviewService(new FakeReviewRepository());
            var result = service.GetReviewsByAlbum(1);
            Assert.HasCount(1, result);
            Assert.AreEqual(9, result[0].Rating);
        }

        [TestMethod]
        public void GetAllReviews_ReturnsAllReviews()
        {
            var service = new ReviewService(new FakeReviewRepository());
            var result = service.GetAllReviews();
            Assert.HasCount(2, result);
        }

        [TestMethod]
        public void HasSongReview_ReturnsTrue()
        {
            var service = new ReviewService(new FakeReviewRepository());
            var result = service.HasSongReview(1, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasAlbumReview_ReturnsTrue()
        {
            var service = new ReviewService(new FakeReviewRepository());
            var result = service.HasAlbumReview(1, 1);
            Assert.IsTrue(result);
        }
    }
}