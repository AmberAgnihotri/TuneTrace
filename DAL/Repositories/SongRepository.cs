using Microsoft.Data.SqlClient;
using DAL.DTOs;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly string _connectionString;

        public SongRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string")
                                ?? string.Empty;
        }

        private const string BaseQuery = @"
            SELECT s.id, s.album_id, s.Title, s.releaseDate, s.duration,
                   a.Title AS AlbumTitle, ar.Name AS ArtistName
            FROM Song s
            LEFT JOIN Album a ON s.album_id = a.id
            LEFT JOIN Artist ar ON a.artist_id = ar.id";

        public List<SongDto> GetSongs()
        {
            var songs = new List<SongDto>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(BaseQuery, conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                songs.Add(MapSong(reader));

            return songs;
        }

        public SongDto? GetSongById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(BaseQuery + " WHERE s.id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return MapSong(reader);
        }

        public List<SongDto> SearchSongs(string query)
        {
            var songs = new List<SongDto>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(BaseQuery + @" WHERE s.Title LIKE @query 
            OR SOUNDEX(s.Title) = SOUNDEX(@exactQuery)", conn);

            cmd.Parameters.AddWithValue("@query", "%" + query + "%");
            cmd.Parameters.AddWithValue("@exactQuery", query);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                songs.Add(MapSong(reader));

            return songs;
        }

        public void AddFavorite(int userId, int songId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO UserSong (UserId, SongId) VALUES (@userId, @songId)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void RemoveFavorite(int userId, int songId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM UserSong WHERE UserId = @userId AND SongId = @songId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddReview(int userId, int songId, string review)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO Review (UserId, SongId, ReviewText) VALUES (@userId, @songId, @review)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            cmd.Parameters.AddWithValue("@review", review);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddRating(int userId, int songId, int rating)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO Review (UserId, SongId, Rating) VALUES (@userId, @songId, @rating)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            cmd.Parameters.AddWithValue("@rating", rating);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private SongDto MapSong(SqlDataReader reader)
        {
            return new SongDto
            {
                Id = (int)reader["id"],
                AlbumId = (int)reader["album_id"],
                Title = reader["Title"].ToString() ?? "",
                Artist = reader["ArtistName"].ToString() ?? "",
                Album = reader["AlbumTitle"].ToString() ?? "",
                ReleaseDate = reader["releaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["releaseDate"],
                Duration = reader["duration"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)reader["duration"]
            };
        }
    }
}