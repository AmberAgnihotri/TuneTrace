using DAL.DTOs;


namespace DAL.Repositories
{
    public interface IUserRepository
    {
        UserDTO? GetFavorites(int userId);
        bool SaveFavoriteSong(int userId, int songId);
        void AddFavoriteSong(int userId, int songId);
        void AddFavoriteAlbum(int userId, int albumId);
        void RemoveFavoriteSong(int userId, int songId);
        void RemoveFavoriteAlbum(int userId, int albumId);
        void AddFavoriteArtist(int userId, int artistId);
        void RemoveFavoriteArtist(int userId, int artistId);
        void SaveSearch(int userId, string searchTerm);
        List<string> GetRecentSearches(int userId);
    }
}