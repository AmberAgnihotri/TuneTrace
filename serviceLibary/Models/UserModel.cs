namespace ServiceLibrary.Models
{
    public class UserModel
    {
        public int Id { get; }
        public string Account { get; }
        public List<int> FavoriteSongIds { get; }
        public List<int> FavoriteAlbumIds { get; }
        public List<int> FavoriteArtistIds { get; }

        public UserModel(
            int id,
            string account,
            List<int> favoriteSongIds,
            List<int> favoriteAlbumIds,
            List<int> favoriteArtistIds)
        {
            Id = id;
            Account = account;
            FavoriteSongIds = favoriteSongIds;
            FavoriteAlbumIds = favoriteAlbumIds;
            FavoriteArtistIds = favoriteArtistIds;
        }
    }
}