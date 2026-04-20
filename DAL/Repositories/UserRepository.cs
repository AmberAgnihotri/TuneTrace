
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DAL.DTOs;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string")
                                ?? string.Empty;
        }

        public UserDTO? GetFavorites(int userId)
        {
            var user = new UserDTO { Id = userId };

            // Get favorite songs
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var songCmd = new SqlCommand(
                    "SELECT SongId FROM UserSong WHERE UserId = @userId", conn);
                songCmd.Parameters.AddWithValue("@userId", userId);
                using var songReader = songCmd.ExecuteReader();
                while (songReader.Read())
                    user.FavoriteSongs.Add((int)songReader["SongId"]);
            }

            // Get favorite albums
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var albumCmd = new SqlCommand(
                    "SELECT AlbumId FROM UserAlbum WHERE UserId = @userId", conn);
                albumCmd.Parameters.AddWithValue("@userId", userId);
                using var albumReader = albumCmd.ExecuteReader();
                while (albumReader.Read())
                    user.FavoriteAlbums.Add((int)albumReader["AlbumId"]);
            }

            // Get favorite artists
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using var artistCmd = new SqlCommand(
                    "SELECT ArtistId FROM UserArtist WHERE UserId = @userId", conn);
                artistCmd.Parameters.AddWithValue("@userId", userId);
                using var artistReader = artistCmd.ExecuteReader();
                while (artistReader.Read())
                    user.FavoriteArtists.Add((int)artistReader["ArtistId"]);
            }

            return user;
        }

        public bool SaveFavoriteSong(int userId, int songId)
        {
            try
            {
                AddFavoriteSong(userId, songId);
                return true;
            }
            catch { return false; }
        }

        public void AddFavoriteSong(int userId, int songId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO UserSong (UserId, SongId) VALUES (@userId, @songId)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddFavoriteAlbum(int userId, int albumId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO UserAlbum (UserId, AlbumId) VALUES (@userId, @albumId)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void RemoveFavoriteSong(int userId, int songId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM UserSong WHERE UserId = @userId AND SongId = @songId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@songId", songId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void RemoveFavoriteAlbum(int userId, int albumId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM UserAlbum WHERE UserId = @userId AND AlbumId = @albumId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            conn.Open();
            cmd.ExecuteNonQuery();

        }
        public void AddFavoriteArtist(int userId, int artistId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO UserArtist (UserId, ArtistId) VALUES (@userId, @artistId)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@artistId", artistId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void RemoveFavoriteArtist(int userId, int artistId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM UserArtist WHERE UserId = @userId AND ArtistId = @artistId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@artistId", artistId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void SaveSearch(int userId, string searchTerm)
        {
            using var conn = new SqlConnection(_connectionString);
            string query = "INSERT INTO SearchHistory (UserId, SearchTerm) VALUES (@userId, @searchTerm)";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<string> GetRecentSearches(int userId)
        {
            var history = new List<string>();
            using var conn = new SqlConnection(_connectionString);
            string query = @"SELECT TOP 5 SearchTerm 
                    FROM SearchHistory 
                    WHERE UserId = @userId 
                    ORDER BY SearchDate DESC";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                history.Add(reader["SearchTerm"].ToString()!);
            return history;
        
        }
    }

}