namespace TuneTrace.Models
{
    public class Beoordeling
    {
        public int Id { get; set; }
        public Gebruiker Gebruiker { get; set; } = new Gebruiker();
        public Album? Album { get; set; }
        public Song? Song { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; } = string.Empty;
        public int GetRating() { return Rating; }
        public string GetReview() { return Review; }
    }
}