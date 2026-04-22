using DAL.Repositories;
using ServiceLibrary.Models;

namespace serviceLibary.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserModel? GetFavorites(int userId)
        {
            var dto = _repository.GetFavorites(userId);
            if (dto == null) return null;
            return new UserModel(
                id: dto.Id,
                account: dto.Account ?? "",
                favoriteSongIds: dto.FavoriteSongs,
                favoriteAlbumIds: dto.FavoriteAlbums,
                favoriteArtistIds: dto.FavoriteArtists
            );
        }

        public void AddFavoriteSong(int userId, int songId)
            => _repository.AddFavoriteSong(userId, songId);

        public void AddFavoriteAlbum(int userId, int albumId)
            => _repository.AddFavoriteAlbum(userId, albumId);

        public void RemoveFavoriteSong(int userId, int songId)
            => _repository.RemoveFavoriteSong(userId, songId);

        public void RemoveFavoriteAlbum(int userId, int albumId)
            => _repository.RemoveFavoriteAlbum(userId, albumId);

        public void AddFavoriteArtist(int userId, int artistId)
            => _repository.AddFavoriteArtist(userId, artistId);

        public void RemoveFavoriteArtist(int userId, int artistId)
            => _repository.RemoveFavoriteArtist(userId, artistId);

        public List<string> GetRecentSearches(int userId)
            => _repository.GetRecentSearches(userId);

        public void SaveSearch(int userId, string searchTerm)
            => _repository.SaveSearch(userId, searchTerm);
    }
}