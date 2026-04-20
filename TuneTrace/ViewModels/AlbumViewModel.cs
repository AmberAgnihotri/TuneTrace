namespace TuneTrace.ViewModels
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ArtistName { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public List<SongViewModel> Songs { get; set; } = new();
    }
}