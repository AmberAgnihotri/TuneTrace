using DAL.DTOs;
using DAL.Repositories;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeArtistRepository : IArtistRepository
    {
        public List<ArtistDTO> GetArtists() => new List<ArtistDTO>
        {
            new ArtistDTO { Id = 1, Name = "Taylor Swift", Biography = "American singer-songwriter", Albums = new(), Songs = new() },
            new ArtistDTO { Id = 2, Name = "The Beatles", Biography = "English rock band", Albums = new(), Songs = new() }
        };

        public ArtistDTO? GetArtistById(int id)
        {
            if (id == 1)
                return new ArtistDTO { Id = 1, Name = "Taylor Swift", Biography = "American singer-songwriter", Albums = new(), Songs = new() };
            return null;
        }

        public List<ArtistDTO> SearchArtists(string query) => new List<ArtistDTO>
        {
            new ArtistDTO { Id = 1, Name = "Taylor Swift", Biography = "American singer-songwriter", Albums = new(), Songs = new() }
        };

        public void AddFavoriteArtist(int userId, int artistId) { }
        public void RemoveFavoriteArtist(int userId, int artistId) { }
    }
}