using DAL.Repositories;
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
        public List<string> GetRecentSearches(int userId)
            => _repository.GetRecentSearches(userId);
    }
}