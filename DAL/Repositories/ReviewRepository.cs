using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DAL.DTOs;

namespace DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;

        public ReviewRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string")
                                ?? string.Empty;
        }

        public void AddReview(int userId, int songId, string review, int rating)
        {
            using var conn = new SqlConnection(_connectionString);
            string query = "INSERT INTO Review (UserId, SongId, Rating, ReviewText) VALUES (@userId, @songId, @rating, @review)";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@review", review);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<ReviewDTO> GetReviewsBySong(int songId)
        {
            var reviews = new List<ReviewDTO>();
            using var conn = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Review WHERE SongId = @songId";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@songId", songId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                reviews.Add(new ReviewDTO
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    SongId = (int)reader["SongId"],
                    AlbumId = reader["AlbumId"] == DBNull.Value ? 0 : (int)reader["AlbumId"],
                    Rating = (int)reader["Rating"],
                    ReviewText = reader["ReviewText"] == DBNull.Value ? string.Empty : reader["ReviewText"].ToString()!
                });
            }
            return reviews;
        }

        public List<ReviewDTO> GetReviewsByAlbum(int albumId)
        {
            var reviews = new List<ReviewDTO>();
            using var conn = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Review WHERE AlbumId = @albumId";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                reviews.Add(new ReviewDTO
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    SongId = reader["SongId"] == DBNull.Value ? 0 : (int)reader["SongId"],
                    AlbumId = (int)reader["AlbumId"],
                    Rating = (int)reader["Rating"],
                    ReviewText = reader["ReviewText"] == DBNull.Value ? string.Empty : reader["ReviewText"].ToString()!
                });
            }
            return reviews;
        }

        public List<ReviewDTO> GetAllReviews()
        {
            var reviews = new List<ReviewDTO>();
            using var conn = new SqlConnection(_connectionString);
            string query = @"
                SELECT r.*, s.Title AS SongTitle, a.Title AS AlbumTitle
                FROM Review r
                LEFT JOIN Song s ON r.SongId = s.id
                LEFT JOIN Album a ON r.AlbumId = a.id";
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                reviews.Add(new ReviewDTO
                {
                    Id = (int)reader["Id"],
                    UserId = (int)reader["UserId"],
                    SongId = reader["SongId"] == DBNull.Value ? 0 : (int)reader["SongId"],
                    AlbumId = reader["AlbumId"] == DBNull.Value ? 0 : (int)reader["AlbumId"],
                    Rating = (int)reader["Rating"],
                    ReviewText = reader["ReviewText"] == DBNull.Value ? string.Empty : reader["ReviewText"].ToString()!,
                    SongTitle = reader["SongTitle"] == DBNull.Value ? string.Empty : reader["SongTitle"].ToString()!,
                    AlbumTitle = reader["AlbumTitle"] == DBNull.Value ? string.Empty : reader["AlbumTitle"].ToString()!
                });
            }
            return reviews;
        }

        public bool HasSongReview(int userId, int songId)
        {
            using var conn = new SqlConnection(_connectionString);
            string query = "SELECT COUNT(*) FROM Review WHERE UserId = @userId AND SongId = @songId";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public bool HasAlbumReview(int userId, int albumId)
        {
            using var conn = new SqlConnection(_connectionString);
            string query = "SELECT COUNT(*) FROM Review WHERE UserId = @userId AND AlbumId = @albumId";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
    }
}