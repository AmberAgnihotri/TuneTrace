namespace DAL.DTO
{
    public class UserDTO
    {
        public int Id { get; }
        public string Account { get; }
        public List<int> FavoriteSongs { get; }
        public List<int> FavoriteAlbums { get; }
        public List<int> FavoriteArtists { get; }

        public UserDTO(int id, string account, List<int> favoriteSongs, List<int> favoriteAlbums, List<int> favoriteArtists)
        {
            Id = id;
            Account = account;
            FavoriteSongs = favoriteSongs;
            FavoriteAlbums = favoriteAlbums;
            FavoriteArtists = favoriteArtists;
        }
    }
}