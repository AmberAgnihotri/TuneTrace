using DAL.DTO;

namespace Interfaces.Interfaces
{
    public interface IUserRepository
    {
        UserDTO? GetFavorites(int userId);
        void AddFavoriteSong(int userId, int songId);
        void AddFavoriteAlbum(int userId, int albumId);
        void AddFavoriteArtist(int userId, int artistId);
        void RemoveFavoriteSong(int userId, int songId);
        void RemoveFavoriteAlbum(int userId, int albumId);
        void RemoveFavoriteArtist(int userId, int artistId);
        void Register(string email, string password);
    }
}