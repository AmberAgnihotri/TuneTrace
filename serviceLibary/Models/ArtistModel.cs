using ServiceLibrary.Models;

namespace serviceLibary.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public List<AlbumModel> Albums { get; set; } = new();
        public List<SongModel> Songs { get; set; } = new();
    }
}