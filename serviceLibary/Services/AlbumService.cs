using DAL.Repositories;
using DAL.DTOs;
using serviceLibary.Models;
using ServiceLibrary.Models;

namespace serviceLibary.Services
{
    public class AlbumService
    {
        private readonly IAlbumRepository _repository;

        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public List<AlbumModel> GetAll()
        {
            return _repository.GetAll().Select(MapAlbum).ToList();
        }

        public AlbumModel? GetById(int id)
        {
            var dto = _repository.GetById(id);
            if (dto == null) return null;
            return MapAlbum(dto);
        }

        public List<AlbumModel> Search(string query)
        {
            return _repository.Search(query).Select(MapAlbum).ToList();
        }

        public void AddFavorite(int userId, int albumId)
        {
            _repository.AddFavorite(userId, albumId);
        }

        public void RemoveFavorite(int userId, int albumId)
        {
            _repository.RemoveFavorite(userId, albumId);
        }

        private AlbumModel MapAlbum(AlbumDto dto)
        {
            return new AlbumModel(
                id: dto.Id,
                title: dto.Title,
                artist: dto.Artist,
                artistId: dto.ArtistId,
                releaseDate: dto.ReleaseDate,
                songs: dto.Songs.Select(s => new SongModel(
                    s.Id,
                    s.AlbumId,
                    s.Title,
                    s.Artist ?? "",
                    s.Album ?? "",
                    s.ReleaseDate,
                    s.Duration
                )).ToList()
            );
        }
    }
}