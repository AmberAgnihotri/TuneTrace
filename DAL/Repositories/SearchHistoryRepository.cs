using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Interfaces.Interfaces;
using DAL.DTO;

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
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO SearchHistory (UserId, SearchTerm, SearchDate) VALUES (@userId, @searchTerm, @date)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while saving the search.", ex);
            }
        }

        public List<SearchHistoryDTO> GetRecentSearches(int userId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 5 Id, UserId, SearchTerm, SearchDate FROM SearchHistory WHERE UserId = @userId ORDER BY SearchDate DESC", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                using var reader = cmd.ExecuteReader();
                var results = new List<SearchHistoryDTO>();
                while (reader.Read())
                    results.Add(new SearchHistoryDTO(
                        id: reader.GetInt32(0),
                        userId: reader.GetInt32(1),
                        searchTerm: reader.GetString(2),
                        searchDate: reader.GetDateTime(3)
                    ));
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the recent searches.", ex);
            }
        }
    }
}