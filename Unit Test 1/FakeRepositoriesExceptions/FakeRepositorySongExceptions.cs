using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositoriesExceptions
{
    public class FakeRepositorySongExceptions : ISongRepository
    {
        public List<SongDTO> GetSongs() =>
            throw new Exception("Something went wrong while retrieving the songs.");

        public SongDTO? GetSongById(int id) =>
            throw new Exception("Something went wrong while retrieving the song.");

        public List<SongDTO> SearchSongs(string query) =>
            throw new Exception("Something went wrong while searching for songs.");

        public void AddFavorite(int userId, int songId) =>
            throw new Exception("Something went wrong while adding the song to favorites.");

        public void RemoveFavorite(int userId, int songId) =>
            throw new Exception("Something went wrong while removing the song from favorites.");

        public void AddRating(int userId, int songId, int rating) =>
            throw new Exception("Something went wrong while adding the rating.");

        public void AddReview(int userId, int songId, string review) =>
            throw new Exception("Something went wrong while adding the review.");
    }
}