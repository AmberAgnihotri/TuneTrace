namespace TuneTrace.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;

        public string GetNaam()
        {
            return Naam;
        }
    }
}