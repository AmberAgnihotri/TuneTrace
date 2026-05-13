using DAL.DTO;
using Interfaces.Interfaces;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeArtistRepository : IArtistRepository
    {
        public List<ArtistDTO> GetArtists() => new List<ArtistDTO>
        {
            new ArtistDTO(1, "Taylor Swift", "American singer-songwriter", new(), new()),
            new ArtistDTO(2, "The Beatles", "English rock band", new(), new())
        };
        public ArtistDTO? GetArtistById(int id)
        {
            if (id == 1)
                return new ArtistDTO(1, "Taylor Swift", "American singer-songwriter", new(), new());
            return null;
        }
        public List<ArtistDTO> SearchArtists(string query) => new List<ArtistDTO>
        {
            new ArtistDTO(1, "Taylor Swift", "American singer-songwriter", new(), new())
        };
        public void AddFavoriteArtist(int userId, int artistId) { }
        public void RemoveFavoriteArtist(int userId, int artistId) { }
    }
}