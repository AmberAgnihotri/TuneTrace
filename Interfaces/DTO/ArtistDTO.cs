
namespace DAL.DTO
{
    public class ArtistDTO
    {
        public int Id { get; }
        public string Name { get; }
        public string Biography { get; }
        public List<AlbumDTO> Albums { get; }
        public List<SongDTO> Songs { get; }

        public ArtistDTO(int id, string name, string biography, List<AlbumDTO> albums, List<SongDTO> songs)
        {
            Id = id;
            Name = name;
            Biography = biography;
            Albums = albums;
            Songs = songs;
        }
    }
}