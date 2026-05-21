using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DAL.DTO;
using Interfaces.Interfaces;

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
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "INSERT INTO Review (UserId, SongId, Rating, ReviewText) VALUES (@userId, @songId, @rating, @review)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@songId", songId);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@review", review);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the review.", ex);
            }
        }

        public void AddAlbumReview(int userId, int albumId, string review, int rating)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "INSERT INTO Review (UserId, AlbumId, Rating, ReviewText) VALUES (@userId, @albumId, @rating, @review)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@review", review);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the album review.", ex);
            }
        }

        public List<ReviewDTO> GetReviewsBySong(int songId)
        {
            try
            {
                var reviews = new List<ReviewDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("SELECT * FROM Review WHERE SongId = @songId", conn);
                cmd.Parameters.AddWithValue("@songId", songId);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    reviews.Add(MapReview(reader));
                return reviews;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the reviews for this song.", ex);
            }
        }

        public List<ReviewDTO> GetReviewsByAlbum(int albumId)
        {
            try
            {
                var reviews = new List<ReviewDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("SELECT * FROM Review WHERE AlbumId = @albumId", conn);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    reviews.Add(MapReview(reader));
                return reviews;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the reviews for this album.", ex);
            }
        }

        public List<ReviewDTO> GetAllReviews()
        {
            try
            {
                var reviews = new List<ReviewDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT r.*, s.Title AS SongTitle, a.Title AS AlbumTitle
                    FROM Review r
                    LEFT JOIN Song s ON r.SongId = s.id
                    LEFT JOIN Album a ON r.AlbumId = a.id", conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reviews.Add(new ReviewDTO(
                        id: (int)reader["Id"],
                        userId: (int)reader["UserId"],
                        albumId: reader["AlbumId"] == DBNull.Value ? 0 : (int)reader["AlbumId"],
                        songId: reader["SongId"] == DBNull.Value ? 0 : (int)reader["SongId"],
                        rating: (int)reader["Rating"],
                        reviewText: reader["ReviewText"] == DBNull.Value ? string.Empty : reader["ReviewText"].ToString()!,
                        songTitle: reader["SongTitle"] == DBNull.Value ? string.Empty : reader["SongTitle"].ToString()!,
                        albumTitle: reader["AlbumTitle"] == DBNull.Value ? string.Empty : reader["AlbumTitle"].ToString()!
                    ));
                }
                return reviews;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving all reviews.", ex);
            }
        }

        public List<ReviewDTO> GetReviewsByUser(int userId)
        {
            try
            {
                var reviews = new List<ReviewDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT r.*, s.Title AS SongTitle, a.Title AS AlbumTitle
                    FROM Review r
                    LEFT JOIN Song s ON r.SongId = s.id
                    LEFT JOIN Album a ON r.AlbumId = a.id
                    WHERE r.UserId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reviews.Add(new ReviewDTO(
                        id: (int)reader["Id"],
                        userId: (int)reader["UserId"],
                        albumId: reader["AlbumId"] == DBNull.Value ? 0 : (int)reader["AlbumId"],
                        songId: reader["SongId"] == DBNull.Value ? 0 : (int)reader["SongId"],
                        rating: (int)reader["Rating"],
                        reviewText: reader["ReviewText"] == DBNull.Value ? string.Empty : reader["ReviewText"].ToString()!,
                        songTitle: reader["SongTitle"] == DBNull.Value ? string.Empty : reader["SongTitle"].ToString()!,
                        albumTitle: reader["AlbumTitle"] == DBNull.Value ? string.Empty : reader["AlbumTitle"].ToString()!
                    ));
                }
                return reviews;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the reviews for this user.", ex);
            }
        }

        public bool HasSongReview(int userId, int songId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Review WHERE UserId = @userId AND SongId = @songId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@songId", songId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while checking the song review.", ex);
            }
        }

        public bool HasAlbumReview(int userId, int albumId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Review WHERE UserId = @userId AND AlbumId = @albumId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while checking the album review.", ex);
            }
        }

        private static ReviewDTO MapReview(SqlDataReader reader)
        {
            return new ReviewDTO(
                id: (int)reader["Id"],
                userId: (int)reader["UserId"],
                albumId: reader["AlbumId"] == DBNull.Value ? 0 : (int)reader["AlbumId"],
                songId: reader["SongId"] == DBNull.Value ? 0 : (int)reader["SongId"],
                rating: (int)reader["Rating"],
                reviewText: reader["ReviewText"] == DBNull.Value ? string.Empty : reader["ReviewText"].ToString()!,
                songTitle: string.Empty,
                albumTitle: string.Empty
            );
        }
    }
}