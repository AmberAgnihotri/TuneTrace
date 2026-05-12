
namespace DAL.DTO
{
    public class ArtistDTO
    {
        public int Id { get; }
        public string Name { get; }
        public string Biography { get; }
        public List<AlbumDto> Albums { get; }
        public List<SongDto> Songs { get; }

        public ArtistDTO(int id, string name, string biography, List<AlbumDto> albums, List<SongDto> songs)
        {
            Id = id;
            Name = name;
            Biography = biography;
            Albums = albums;
            Songs = songs;
        }
    }
}