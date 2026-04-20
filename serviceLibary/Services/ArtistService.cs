using DAL.Repositories;
using DAL.DTOs;
using serviceLibary.Models;
using ServiceLibrary.Models;

namespace serviceLibary.Services
{
    public class ArtistService
    {
        private readonly IArtistRepository _repository;

        public ArtistService(IArtistRepository repository)
        {
            _repository = repository;
        }

        public List<ArtistModel> GetArtists()
        {
            return _repository.GetArtists().Select(MapArtist).ToList();
        }

        public ArtistModel? GetArtistById(int id)
        {
            var dto = _repository.GetArtistById(id);
            if (dto == null) return null;
            return MapArtist(dto);
        }

        public List<ArtistModel> SearchArtists(string query)
        {
            return _repository.SearchArtists(query).Select(MapArtist).ToList();
        }

        public void AddFavoriteArtist(int userId, int artistId)
        {
            _repository.AddFavoriteArtist(userId, artistId);
        }

        public void RemoveFavoriteArtist(int userId, int artistId)
        {
            _repository.RemoveFavoriteArtist(userId, artistId);
        }

        private ArtistModel MapArtist(ArtistDTO dto)
        {
            return new ArtistModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Biography = dto.Biography,
                Albums = dto.Albums.Select(a => new AlbumModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ReleaseDate = a.ReleaseDate
                }).ToList(),
                Songs = dto.Songs.Select(s => new SongModel(
                    s.Id,
                    s.AlbumId,
                    s.Title,
                    s.Artist ?? "",
                    s.Album ?? "",
                    s.ReleaseDate,
                    s.Duration
                )).ToList()
            };
        }
    }
}