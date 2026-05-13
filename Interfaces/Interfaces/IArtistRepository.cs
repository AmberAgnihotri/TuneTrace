using DAL.DTO;

namespace Interfaces.Interfaces
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