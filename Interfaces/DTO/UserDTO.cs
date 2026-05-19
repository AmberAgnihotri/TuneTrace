namespace DAL.DTO
{
    public class UserDTO
    {
        public int Id { get; }
        public string Email { get; }
        public string Password { get; }
        public List<int> FavoriteSongs { get; }
        public List<int> FavoriteAlbums { get; }
        public List<int> FavoriteArtists { get; }

        public UserDTO(int id, string email, string password, List<int> favoriteSongs, List<int> favoriteAlbums, List<int> favoriteArtists)
        {
            Id = id;
            Email = email;
            Password = password;
            FavoriteSongs = favoriteSongs;
            FavoriteAlbums = favoriteAlbums;
            FavoriteArtists = favoriteArtists;
        }
    }
}