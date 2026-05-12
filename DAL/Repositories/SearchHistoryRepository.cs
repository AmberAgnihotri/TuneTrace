using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace DAL.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly string _connectionString;
        public SearchHistoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
        }
        public void SaveSearch(int userId, string searchTerm)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO SearchHistory (UserId, SearchTerm, SearchDate) VALUES (@userId, @searchTerm, @date)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
        public List<string> GetRecentSearches(int userId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT TOP 5 SearchTerm FROM SearchHistory WHERE UserId = @userId ORDER BY SearchDate DESC", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using var reader = cmd.ExecuteReader();
            var results = new List<string>();
            while (reader.Read())
                results.Add(reader.GetString(0));
            return results;
        }
    }
}