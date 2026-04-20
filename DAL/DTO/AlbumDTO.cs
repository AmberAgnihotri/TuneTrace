namespace DAL.DTOs
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Artist { get; set; } = string.Empty;
        public List<SongDto> Songs { get; set; } = new();
    }
}