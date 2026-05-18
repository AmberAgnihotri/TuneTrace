using Interfaces.Interfaces;
using DAL.DTO;

namespace Unit_Test_1.FakeRepositories
{
    public class FakeSearchHistoryRepository : ISearchHistoryRepository
    {
        public List<SearchHistoryDTO> GetRecentSearches(int userId)
            => new List<SearchHistoryDTO>
            {
                new SearchHistoryDTO(1, userId, "Taylor Swift", DateTime.Now),
                new SearchHistoryDTO(2, userId, "Midnights", DateTime.Now)
            };

        public void SaveSearch(int userId, string searchTerm) { }
    }
}