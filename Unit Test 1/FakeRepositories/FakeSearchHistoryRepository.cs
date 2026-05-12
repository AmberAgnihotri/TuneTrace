using DAL.Repositories;
namespace Unit_Test_1.FakeRepositories
{
    public class FakeSearchHistoryRepository : ISearchHistoryRepository
    {
        public List<string> GetRecentSearches(int userId)
            => new List<string> { "Taylor Swift", "Midnights" };
        public void SaveSearch(int userId, string searchTerm) { }
    }
}