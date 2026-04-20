namespace ServiceLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public List<int> FavoriteSongIds { get; set; } = new();
        public List<int> FavoriteAlbumIds { get; set; } = new();
        public List<int> FavoriteArtistIds { get; set; } = new();
    }
}