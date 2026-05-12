namespace ServiceLibrary.Models
{
    public class SearchHistoryModel
    {
        public int Id { get; }
        public int UserId { get; }
        public string SearchTerm { get; }
        public DateTime SearchDate { get; }

        public SearchHistoryModel(int id, int userId, string searchTerm, DateTime searchDate)
        {
            Id = id;
            UserId = userId;
            SearchTerm = searchTerm;
            SearchDate = searchDate;
        }
    }
}