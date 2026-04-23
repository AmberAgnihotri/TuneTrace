    using ServiceLibrary.Models;

namespace serviceLibary.Models
{
    public class AlbumModel
    {
        public int Id { get; }
        public string Title { get; }
        public string Artist { get; }
        public int ArtistId { get; }
        public DateTime ReleaseDate { get; }
        private List<SongModel> songs;
        public IReadOnlyList<SongModel> Songs{ get { return songs.AsReadOnly(); } }

        public AlbumModel(
            int id,
            string title,
            string artist,
            int artistId,
            DateTime releaseDate,
            List<SongModel> songs)
        {
            Id = id;
            Title = title;
            Artist = artist;
            ArtistId = artistId;
            ReleaseDate = releaseDate;
            this.songs = songs;
        }
    }
}