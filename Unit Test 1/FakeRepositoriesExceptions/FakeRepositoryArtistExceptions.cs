using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositoriesExceptions
{
    public class FakeRepositoryArtistExceptions : IArtistRepository
    {
        public List<ArtistDTO> GetArtists() =>
            throw new Exception("Something went wrong while retrieving the artists.");

        public ArtistDTO? GetArtistById(int id) =>
            throw new Exception("Something went wrong while retrieving the artist.");

        public List<ArtistDTO> SearchArtists(string query) =>
            throw new Exception("Something went wrong while searching for artists.");

        public void AddFavoriteArtist(int userId, int artistId) =>
            throw new Exception("Something went wrong while adding the artist to favorites.");

        public void RemoveFavoriteArtist(int userId, int artistId) =>
            throw new Exception("Something went wrong while removing the artist from favorites.");
    }
}