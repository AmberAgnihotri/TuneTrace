using DAL.DTO;
using Interfaces.Interfaces;
using ServiceLibrary.Models;

namespace ServiceLibrary.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public void AddReview(int userId, int songId, string review, int rating)
        {
            if (rating < 1 || rating > 10)
                throw new ArgumentException("Rating must be between 1 and 10.");
            _repository.AddReview(userId, songId, review, rating);
        }

        public void AddAlbumReview(int userId, int albumId, string review, int rating)
        {
            if (rating < 1 || rating > 10)
                throw new ArgumentException("Rating must be between 1 and 10.");
            _repository.AddAlbumReview(userId, albumId, review, rating);
        }

        public List<ReviewModel> GetReviewsBySong(int songId)
        {
            return _repository.GetReviewsBySong(songId).Select(MapReview).ToList();
        }

        public List<ReviewModel> GetReviewsByAlbum(int albumId)
        {
            return _repository.GetReviewsByAlbum(albumId).Select(MapReview).ToList();
        }

        public List<ReviewModel> GetAllReviews()
        {
            return _repository.GetAllReviews().Select(MapReview).ToList();
        }

        public bool HasSongReview(int userId, int songId)
        {
            return _repository.HasSongReview(userId, songId);
        }

        public bool HasAlbumReview(int userId, int albumId)
        {
            return _repository.HasAlbumReview(userId, albumId);
        }

        public List<ReviewModel> GetReviewsByUser(int userId)
        {
            return _repository.GetReviewsByUser(userId).Select(MapReview).ToList();
        }

        private ReviewModel MapReview(ReviewDTO dto)
        {
            return new ReviewModel(
                id: dto.Id,
                userId: dto.UserId,
                songId: dto.SongId,
                albumId: dto.AlbumId,
                rating: dto.Rating,
                reviewText: dto.ReviewText,
                songTitle: dto.SongTitle ?? "",
                albumTitle: dto.AlbumTitle ?? ""
            );
        }
    }
}
