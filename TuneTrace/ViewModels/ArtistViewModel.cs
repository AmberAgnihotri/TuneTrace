namespace TuneTrace.ViewModels
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public List<AlbumViewModel> Albums { get; set; } = new();
        public List<SongViewModel> Songs { get; set; } = new();
    }
}