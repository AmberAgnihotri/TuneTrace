namespace TuneTrace.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public Artist Artist { get; set; } = new Artist();
        public List<Song> Songs { get; set; } = new List<Song>();

        public string GetTitel()
        {
            return Titel;
        }

        public List<Song> GetSongs()
        {
            return Songs;
        }
    }
}