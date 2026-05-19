
namespace TuneTrace.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public List<SongViewModel> FavoriteSongs { get; set; } = new();
        public List<AlbumViewModel> FavoriteAlbums { get; set; } = new();
        public List<ArtistViewModel> FavoriteArtists { get; set; } = new();
    }
}