using DAL.DTO;
using Interfaces.Interfaces;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeReviewRepository : IReviewRepository
    {
        public void AddReview(int userId, int songId, string review, int rating) { }
        public void AddAlbumReview(int userId, int albumId, string review, int rating) { }
        public List<ReviewDTO> GetReviewsBySong(int songId) => new List<ReviewDTO>
        {
            new ReviewDTO(1, 1, 0, songId, 8, "Great song!", "", "")
        };
        public List<ReviewDTO> GetReviewsByAlbum(int albumId) => new List<ReviewDTO>
        {
            new ReviewDTO(2, 1, albumId, 0, 9, "Great album!", "", "")
        };
        public List<ReviewDTO> GetAllReviews() => new List<ReviewDTO>
        {
            new ReviewDTO(1, 1, 0, 1, 8, "Great song!", "Lavender Haze", ""),
            new ReviewDTO(2, 1, 1, 0, 9, "Great album!", "", "Midnights")
        };
        public bool HasSongReview(int userId, int songId) => true;
        public bool HasAlbumReview(int userId, int albumId) => true;
    }
}