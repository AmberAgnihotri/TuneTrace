using DAL.DTO;

namespace Interfaces.Interfaces
{
    public interface ISongRepository
    {
        List<SongDTO> GetSongs();
        SongDTO? GetSongById(int id);

        List<SongDTO> SearchSongs(string query);

        void AddFavorite(int userId, int songId);
        void RemoveFavorite(int userId, int songId);

        void AddRating(int userId, int songId, int rating);
        void AddReview(int userId, int songId, string review);
    }
}