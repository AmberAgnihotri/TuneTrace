public interface IReviewRepository
{
    void AddReview(int userId, int songId, string review, int rating);
    void AddAlbumReview(int userId, int albumId, string review, int rating);
    List<ReviewDTO> GetReviewsBySong(int songId);
    List<ReviewDTO> GetReviewsByAlbum(int albumId);
    List<ReviewDTO> GetAllReviews();
    bool HasSongReview(int userId, int songId);
    bool HasAlbumReview(int userId, int albumId);
}