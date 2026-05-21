using Interfaces.Interfaces;
using ServiceLibrary.Models;
using DAL.DTO;

namespace serviceLibary.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void AddFavoriteSong(int userId, int songId)
            => _repository.AddFavoriteSong(userId, songId);

        public void AddFavoriteAlbum(int userId, int albumId)
            => _repository.AddFavoriteAlbum(userId, albumId);

        public void AddFavoriteArtist(int userId, int artistId)
            => _repository.AddFavoriteArtist(userId, artistId);

        public void RemoveFavoriteSong(int userId, int songId)
            => _repository.RemoveFavoriteSong(userId, songId);

        public void RemoveFavoriteAlbum(int userId, int albumId)
            => _repository.RemoveFavoriteAlbum(userId, albumId);

        public void RemoveFavoriteArtist(int userId, int artistId)
            => _repository.RemoveFavoriteArtist(userId, artistId);

        public void Register(string email, string password, string confirmPassword)
        {
            if (password.Length < 8)
                throw new Exception("Password must be at least 8 characters long.");
            if (password != confirmPassword)
                throw new Exception("Passwords do not match.");
            _repository.Register(email, password);
        }

        public UserModel? GetFavorites(int userId)
        {
            var dto = _repository.GetFavorites(userId);
            if (dto == null) return null;
            return MapUser(dto);
        }

        public UserModel? Login(string email, string password)
        {
            var dto = _repository.Login(email, password);
            if (dto == null) return null;
            return MapUser(dto);
        }
        private UserModel MapUser(UserDTO dto)
        {
            return new UserModel(
                id: dto.Id,
                email: dto.Email,
                password: dto.Password,
                favoriteSongIds: dto.FavoriteSongs,
                favoriteAlbumIds: dto.FavoriteAlbums,
                favoriteArtistIds: dto.FavoriteArtists
            );
        }
    }
}