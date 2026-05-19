using DAL.DTO;

namespace Interfaces.Interfaces
{
    public interface IAlbumRepository
    {
        List<AlbumDTO> GetAll();
        AlbumDTO? GetById(int id);
        List<AlbumDTO> Search(string query);
        void AddFavorite(int userId, int albumId);
        void RemoveFavorite(int userId, int albumId);
    }
}