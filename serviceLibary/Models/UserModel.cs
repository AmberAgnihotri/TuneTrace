namespace ServiceLibrary.Models
{
    public class UserModel
    {
        public int Id { get; }
        public string Email { get; }
        public string Password { get; }
        private List<int> favoriteSongIds;
        public IReadOnlyList<int> FavoriteSongIds { get { return favoriteSongIds.AsReadOnly(); } }
        private List<int> favoriteAlbumIds;
        public IReadOnlyList<int> FavoriteAlbumIds { get { return favoriteAlbumIds.AsReadOnly(); } }
        private List<int> favoriteArtistIds;
        public IReadOnlyList<int> FavoriteArtistIds { get { return favoriteArtistIds.AsReadOnly(); } }

        public UserModel(
            int id,
            string email,
            string password,
            List<int> favoriteSongIds,
            List<int> favoriteAlbumIds,
            List<int> favoriteArtistIds)
        {
            Id = id;
            Email = email;
            Password = password;
            this.favoriteSongIds = favoriteSongIds;
            this.favoriteAlbumIds = favoriteAlbumIds;
            this.favoriteArtistIds = favoriteArtistIds;
        }
    }
}