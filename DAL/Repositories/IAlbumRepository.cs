using DAL.DTOs;

namespace DAL.Repositories
{
    public interface IAlbumRepository
    {
        List<AlbumDto> GetAll();
        AlbumDto? GetById(int id);
        List<AlbumDto> Search(string query);
        void AddFavorite(int userId, int albumId);
        void RemoveFavorite(int userId, int albumId);
    }
}