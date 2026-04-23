using ServiceLibrary.Models;

namespace serviceLibary.Models
{
    public class ArtistModel
    {
        public int Id { get; }
        public string Name { get; }
        public string Biography { get; }
        private List<AlbumModel> albums;
        public IReadOnlyList<AlbumModel> Albums { get { return albums.AsReadOnly(); } }
        private List<SongModel> songs;
        public IReadOnlyList<SongModel> Songs { get { return songs.AsReadOnly(); } }

        public ArtistModel(
            int id,
            string name,
            string biography,
            List<AlbumModel> albums,
            List<SongModel> songs)
        {
            Id = id;
            Name = name;
            Biography = biography;
            this.albums = albums;
            this.songs = songs;
        }
    }
}