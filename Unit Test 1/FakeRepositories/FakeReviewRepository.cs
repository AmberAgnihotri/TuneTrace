using DAL.DTOs;
using DAL.Repositories;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeReviewRepository : IReviewRepository
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
}