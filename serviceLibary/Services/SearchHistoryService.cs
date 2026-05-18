using Interfaces.Interfaces;
using DAL.DTO;
using ServiceLibrary.Models;

namespace ServiceLibrary.Services
{
    public class SearchHistoryService
    {
        private readonly ISearchHistoryRepository _repository;

        public SearchHistoryService(ISearchHistoryRepository repository)
        {
            _repository = repository;
        }

        public void SaveSearch(int userId, string searchTerm)
            => _repository.SaveSearch(userId, searchTerm);

        public List<SearchHistoryModel> GetRecentSearches(int userId)
        {
            return _repository.GetRecentSearches(userId).Select(MapSearchHistory).ToList();
        }

        private SearchHistoryModel MapSearchHistory(SearchHistoryDTO dto)
        {
            return new SearchHistoryModel(
                id: dto.Id,
                userId: dto.UserId,
                searchTerm: dto.SearchTerm,
                searchDate: dto.SearchDate
            );
        }
    }
}