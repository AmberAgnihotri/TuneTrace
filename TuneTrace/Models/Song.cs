namespace TuneTrace.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public Album Album { get; set; } = new Album();

        public string GetTitel()
        {
            return Titel;
        }
    }
}