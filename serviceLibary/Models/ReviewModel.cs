namespace ServiceLibrary.Models
{
    public class ReviewModel
    {
        public int Id { get; }
        public int UserId { get; }
        public int AlbumId { get; }
        public int SongId { get; }
        public int Rating { get; }
        public string ReviewText { get; }
        public string SongTitle { get; }
        public string AlbumTitle { get; }

        public ReviewModel(
            int id,
            int userId,
            int albumId,
            int songId,
            int rating,
            string reviewText,
            string songTitle,
            string albumTitle)
        {
            Id = id;
            UserId = userId;
            AlbumId = albumId;
            SongId = songId;
            Rating = rating;
            ReviewText = reviewText;
            SongTitle = songTitle;
            AlbumTitle = albumTitle;
        }
    }
}