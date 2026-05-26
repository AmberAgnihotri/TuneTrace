using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositoriesExceptions
{
    public class FakeRepositoryReviewExceptions : IReviewRepository
    {
        public void AddReview(int userId, int songId, string review, int rating) =>
            throw new Exception("Something went wrong while adding the review.");

        public void AddAlbumReview(int userId, int albumId, string review, int rating) =>
            throw new Exception("Something went wrong while adding the album review.");

        public List<ReviewDTO> GetReviewsBySong(int songId) =>
            throw new Exception("Something went wrong while retrieving the reviews for this song.");

        public List<ReviewDTO> GetReviewsByAlbum(int albumId) =>
            throw new Exception("Something went wrong while retrieving the reviews for this album.");

        public List<ReviewDTO> GetAllReviews() =>
            throw new Exception("Something went wrong while retrieving all reviews.");

        public List<ReviewDTO> GetReviewsByUser(int userId) =>
            throw new Exception("Something went wrong while retrieving the reviews for this user.");

        public bool HasSongReview(int userId, int songId) =>
            throw new Exception("Something went wrong while checking the song review.");

        public bool HasAlbumReview(int userId, int albumId) =>
            throw new Exception("Something went wrong while checking the album review.");
    }
}