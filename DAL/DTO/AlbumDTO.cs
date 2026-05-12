namespace DAL.DTO
{
    public class AlbumDto
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public string Artist { get; }
        public int ArtistId { get; }
        public List<SongDto> Songs { get; }

        public AlbumDto(int id, string title, DateTime releaseDate, string artist, int artistId, List<SongDto> songs)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Artist = artist;
            ArtistId = artistId;
            Songs = songs;
        }
    }
}