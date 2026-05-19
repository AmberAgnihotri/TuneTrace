namespace DAL.DTO
{
    public class AlbumDTO
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public string Artist { get; }
        public int ArtistId { get; }
        public List<SongDTO> Songs { get; }

        public AlbumDTO(int id, string title, DateTime releaseDate, string artist, int artistId, List<SongDTO> songs)
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