using ServiceLibrary.Services;
using Unit_Test_1.FakeRepositoriesExceptions;

namespace Unit_Test_1.ServiceExceptionTests
{
    [TestClass]
    public class ReviewServiceExceptionTest
    {
        [TestMethod]
        public void AddReview_ThrowsArgumentException_WhenRatingTooLow()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.AddReview(1, 1, "Great song", 0);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Rating must be between 1 and 10.", ex.Message);
            }
        }

        [TestMethod]
        public void AddReview_ThrowsArgumentException_WhenRatingTooHigh()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.AddReview(1, 1, "Great song", 11);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Rating must be between 1 and 10.", ex.Message);
            }
        }

        [TestMethod]
        public void AddReview_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.AddReview(1, 1, "Great song", 5);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the review.", ex.Message);
            }
        }

        [TestMethod]
        public void AddAlbumReview_ThrowsArgumentException_WhenRatingTooLow()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.AddAlbumReview(1, 1, "Great album", 0);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Rating must be between 1 and 10.", ex.Message);
            }
        }

        [TestMethod]
        public void AddAlbumReview_ThrowsArgumentException_WhenRatingTooHigh()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.AddAlbumReview(1, 1, "Great album", 11);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Rating must be between 1 and 10.", ex.Message);
            }
        }

        [TestMethod]
        public void AddAlbumReview_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.AddAlbumReview(1, 1, "Great album", 5);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while adding the album review.", ex.Message);
            }
        }

        [TestMethod]
        public void GetReviewsBySong_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.GetReviewsBySong(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the reviews for this song.", ex.Message);
            }
        }

        [TestMethod]
        public void GetReviewsByAlbum_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.GetReviewsByAlbum(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the reviews for this album.", ex.Message);
            }
        }

        [TestMethod]
        public void GetAllReviews_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.GetAllReviews();
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving all reviews.", ex.Message);
            }
        }

        [TestMethod]
        public void GetReviewsByUser_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.GetReviewsByUser(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while retrieving the reviews for this user.", ex.Message);
            }
        }

        [TestMethod]
        public void HasSongReview_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.HasSongReview(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while checking the song review.", ex.Message);
            }
        }

        [TestMethod]
        public void HasAlbumReview_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            var service = new ReviewService(new FakeRepositoryReviewExceptions());

            // Act
            try
            {
                service.HasAlbumReview(1, 1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual("Something went wrong while checking the album review.", ex.Message);
            }
        }
    }
}
