
namespace TuneTrace.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Account { get; set; } = string.Empty;
        public List<SongViewModel> FavoriteSongs { get; set; } = new();
        public List<AlbumViewModel> FavoriteAlbums { get; set; } = new();
    }
}