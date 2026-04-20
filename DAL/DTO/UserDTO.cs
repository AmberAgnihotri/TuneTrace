
namespace DAL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public List<int> FavoriteSongs { get; set; } = new();
        public List<int> FavoriteAlbums { get; set; } = new();
        public List<int> FavoriteArtists { get; set; } = new();
    }
}