namespace TuneTrace.ViewModels
{
    public class SongViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;

        public string Album { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Duration { get; set; }
    }
}