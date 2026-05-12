namespace DAL.Repositories
{
    public interface ISearchHistoryRepository
    {
        void SaveSearch(int userId, string searchTerm);
        List<string> GetRecentSearches(int userId);
    }
}