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
            return _repository.GetReviewsBySong(songId).Select(r => new ReviewModel
            {
                Id = r.Id,
                UserId = r.UserId,
                SongId = r.SongId,
                AlbumId = r.AlbumId,
                Rating = r.Rating,
                ReviewText = r.ReviewText
            }).ToList();
        }

        public List<ReviewModel> GetReviewsByAlbum(int albumId)
        {
            return _repository.GetReviewsByAlbum(albumId).Select(r => new ReviewModel
            {
                Id = r.Id,
                UserId = r.UserId,
                SongId = r.SongId,
                AlbumId = r.AlbumId,
                Rating = r.Rating,
                ReviewText = r.ReviewText
            }).ToList();
        }

        public List<ReviewModel> GetAllReviews()
        {
            return _repository.GetAllReviews().Select(r => new ReviewModel
            {
                Id = r.Id,
                UserId = r.UserId,
                SongId = r.SongId,
                AlbumId = r.AlbumId,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                SongTitle = r.SongTitle,
                AlbumTitle = r.AlbumTitle
            }).ToList();
        }

        public bool HasSongReview(int userId, int songId)
        {
            return _repository.HasSongReview(userId, songId);
        }

        public bool HasAlbumReview(int userId, int albumId)
        {
            return _repository.HasAlbumReview(userId, albumId);
        }
    }
}