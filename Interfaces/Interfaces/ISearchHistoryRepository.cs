using DAL.DTO;

namespace Interfaces.Interfaces
{
    public interface ISearchHistoryRepository
    {
        void SaveSearch(int userId, string searchTerm);
        List<SearchHistoryDTO> GetRecentSearches(int userId);
    }
}