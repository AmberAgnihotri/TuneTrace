using Microsoft.Data.SqlClient;
using DAL.DTO;
using Microsoft.Extensions.Configuration;
using Interfaces.Interfaces;

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

        public List<SongDTO> GetSongs()
        {
            try
            {
                var songs = new List<SongDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(BaseQuery, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    songs.Add(MapSong(reader));
                return songs;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the songs.", ex);
            }
        }

        public SongDTO? GetSongById(int id)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(BaseQuery + " WHERE s.id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return MapSong(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the song.", ex);
            }
        }

        public List<SongDTO> SearchSongs(string query)
        {
            try
            {
                var songs = new List<SongDTO>();
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
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while searching for songs.", ex);
            }
        }

        public void AddFavorite(int userId, int songId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "INSERT INTO UserSong (UserId, SongId) VALUES (@userId, @songId)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@songId", songId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the song to favorites.", ex);
            }
        }

        public void RemoveFavorite(int userId, int songId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "DELETE FROM UserSong WHERE UserId = @userId AND SongId = @songId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@songId", songId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while removing the song from favorites.", ex);
            }
        }

        public void AddReview(int userId, int songId, string review)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the review.", ex);
            }
        }

        public void AddRating(int userId, int songId, int rating)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the rating.", ex);
            }
        }

        private static SongDTO MapSong(SqlDataReader reader)
        {
            return new SongDTO(
                id: (int)reader["id"],
                albumId: (int)reader["album_id"],
                title: reader["Title"].ToString() ?? "",
                artist: reader["ArtistName"].ToString() ?? "",
                album: reader["AlbumTitle"].ToString() ?? "",
                releaseDate: reader["releaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["releaseDate"],
                duration: reader["duration"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)reader["duration"]
            );
        }
    }
}