namespace ServiceLibrary.Models
{
    public class UserModel
    {
        public int Id { get; }
        public string Account { get; }
        private List<int> favoriteSongIds;
        public IReadOnlyList<int> FavoriteSongIds { get { return favoriteSongIds.AsReadOnly(); } }
        private List<int> favoriteAlbumIds;
        public IReadOnlyList<int> FavoriteAlbumIds { get { return favoriteAlbumIds.AsReadOnly(); } }
        private List<int> favoriteArtistIds;
        public IReadOnlyList<int> FavoriteArtistIds { get { return favoriteArtistIds.AsReadOnly(); } }

        public UserModel(
            int id,
            string account,
            List<int> favoriteSongIds,
            List<int> favoriteAlbumIds,
            List<int> favoriteArtistIds)
        {
            Id = id;
            Account = account;
            this.favoriteSongIds = favoriteSongIds;
            this.favoriteAlbumIds = favoriteAlbumIds;
            this.favoriteArtistIds = favoriteArtistIds;
        }
    }
}