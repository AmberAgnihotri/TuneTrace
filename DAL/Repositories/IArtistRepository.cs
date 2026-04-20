using DAL.DTOs;

namespace DAL.Repositories
{
    public interface IArtistRepository
    {
        List<ArtistDTO> GetArtists();
        ArtistDTO? GetArtistById(int id);
        List<ArtistDTO> SearchArtists(string query);
        void AddFavoriteArtist(int userId, int artistId);
        void RemoveFavoriteArtist(int userId, int artistId);
    }
}