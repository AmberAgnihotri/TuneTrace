using ServiceLibrary.Models;

namespace serviceLibary.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<SongModel> Songs { get; set; } = new();
    }
}