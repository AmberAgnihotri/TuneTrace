using DAL.DTOs;
using DAL.Repositories;

namespace BLL.Services
{
    public class AlbumService
    {
        private readonly IAlbumRepository _repo;

        public AlbumService(IAlbumRepository repo)
        {
            _repo = repo;
        }

        public List<AlbumDto> GetAll() => _repo.GetAll();
        public AlbumDto? GetById(int id) => _repo.GetById(id);
        public List<AlbumDto> Search(string query) => _repo.Search(query);
        public void AddFavorite(int userId, int albumId) => _repo.AddFavorite(userId, albumId);
        public void RemoveFavorite(int userId, int albumId) => _repo.RemoveFavorite(userId, albumId);
    }
}