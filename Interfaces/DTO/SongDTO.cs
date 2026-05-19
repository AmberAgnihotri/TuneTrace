

namespace DAL.DTO
{
    public class SongDTO
    {
        public int Id { get; }
        public int AlbumId { get; }
        public string Title { get; }
        public string Artist { get; }
        public string Album { get; }
        public DateTime ReleaseDate { get; }
        public TimeSpan Duration { get; }

        public SongDTO(int id, int albumId, string title, string artist, string album, DateTime releaseDate, TimeSpan duration)
        {
            Id = id;
            AlbumId = albumId;
            Title = title;
            Artist = artist;
            Album = album;
            ReleaseDate = releaseDate;
            Duration = duration;
        }
    }
}