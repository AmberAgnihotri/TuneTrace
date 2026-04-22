using DAL.DTOs;
using DAL.Repositories;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        public UserDTO? GetFavorites(int userId)
        {
            if (userId == 1)
                return new UserDTO
                {
                    Id = 1,
                    Account = "",
                    FavoriteSongs = new List<int> { 1, 2 },
                    FavoriteAlbums = new List<int> { 1 },
                    FavoriteArtists = new List<int> { 1 }
                };
            return null;
        }

        public bool SaveFavoriteSong(int userId, int songId) => true;
        public void AddFavoriteSong(int userId, int songId) { }
        public void RemoveFavoriteSong(int userId, int songId) { }
        public void AddFavoriteAlbum(int userId, int albumId) { }
        public void RemoveFavoriteAlbum(int userId, int albumId) { }
        public void AddFavoriteArtist(int userId, int artistId) { }
        public void RemoveFavoriteArtist(int userId, int artistId) { }
        public List<string> GetRecentSearches(int userId) => new List<string> { "Taylor Swift", "Midnights" };
        public void SaveSearch(int userId, string searchTerm) { }
    }
}