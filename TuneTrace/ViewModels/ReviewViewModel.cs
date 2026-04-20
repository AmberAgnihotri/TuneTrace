
namespace TuneTrace.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; } = string.Empty;
        public string AlbumTitle { get; set; } = string.Empty;
        public string SongTitle { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
    }
}