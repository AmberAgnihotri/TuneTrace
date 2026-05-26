using DAL.DTO;
using Interfaces.Interfaces;

namespace Unit_Test_1.FakeRepositoriesExceptions
{
    public class FakeRepositorySearchHistoryExceptions : ISearchHistoryRepository
    {
        public void SaveSearch(int userId, string searchTerm) =>
            throw new Exception("Something went wrong while saving the search.");

        public List<SearchHistoryDTO> GetRecentSearches(int userId) =>
            throw new Exception("Something went wrong while retrieving the recent searches.");
    }
}