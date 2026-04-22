using ServiceLibrary.Models;

namespace serviceLibary.Models
{
    public class ArtistModel
    {
        public int Id { get; }
        public string Name { get; }
        public string Biography { get; }
        public List<AlbumModel> Albums { get; }
        public List<SongModel> Songs { get; }

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
            Albums = albums;
            Songs = songs;
        }
    }
}