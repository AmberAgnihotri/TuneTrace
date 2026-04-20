using DAL.DTOs;

namespace DAL.Repositories
{
    public interface ISongRepository
    {
        List<SongDto> GetSongs();
        SongDto? GetSongById(int id);

        List<SongDto> SearchSongs(string query);

        void AddFavorite(int userId, int songId);
        void RemoveFavorite(int userId, int songId);

        void AddRating(int userId, int songId, int rating);
        void AddReview(int userId, int songId, string review);
    }
}