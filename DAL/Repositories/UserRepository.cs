
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DAL.DTO;
using Interfaces.Interfaces;

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
            try
            {
                var favoriteSongs = new List<int>();
                var favoriteAlbums = new List<int>();
                var favoriteArtists = new List<int>();

                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using var songCmd = new SqlCommand("SELECT SongId FROM UserSong WHERE UserId = @userId", conn);
                    songCmd.Parameters.AddWithValue("@userId", userId);
                    using var songReader = songCmd.ExecuteReader();
                    while (songReader.Read())
                        favoriteSongs.Add((int)songReader["SongId"]);
                }

                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using var albumCmd = new SqlCommand("SELECT AlbumId FROM UserAlbum WHERE UserId = @userId", conn);
                    albumCmd.Parameters.AddWithValue("@userId", userId);
                    using var albumReader = albumCmd.ExecuteReader();
                    while (albumReader.Read())
                        favoriteAlbums.Add((int)albumReader["AlbumId"]);
                }

                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using var artistCmd = new SqlCommand("SELECT ArtistId FROM UserArtist WHERE UserId = @userId", conn);
                    artistCmd.Parameters.AddWithValue("@userId", userId);
                    using var artistReader = artistCmd.ExecuteReader();
                    while (artistReader.Read())
                        favoriteArtists.Add((int)artistReader["ArtistId"]);
                }

                return new UserDTO(userId, string.Empty, favoriteSongs, favoriteAlbums, favoriteArtists);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the favorites.", ex);
            }
        }

        public bool SaveFavoriteSong(int userId, int songId)
        {
            try { AddFavoriteSong(userId, songId); return true; }
            catch { return false; }
        }

        public void AddFavoriteSong(int userId, int songId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("INSERT INTO UserSong (UserId, SongId) VALUES (@userId, @songId)", conn);
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

        public void AddFavoriteAlbum(int userId, int albumId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("INSERT INTO UserAlbum (UserId, AlbumId) VALUES (@userId, @albumId)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the album to favorites.", ex);
            }
        }

        public void RemoveFavoriteSong(int userId, int songId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("DELETE FROM UserSong WHERE UserId = @userId AND SongId = @songId", conn);
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

        public void RemoveFavoriteAlbum(int userId, int albumId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("DELETE FROM UserAlbum WHERE UserId = @userId AND AlbumId = @albumId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while removing the album from favorites.", ex);
            }
        }

        public void AddFavoriteArtist(int userId, int artistId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("INSERT INTO UserArtist (UserId, ArtistId) VALUES (@userId, @artistId)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@artistId", artistId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while adding the artist to favorites.", ex);
            }
        }

        public void RemoveFavoriteArtist(int userId, int artistId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand("DELETE FROM UserArtist WHERE UserId = @userId AND ArtistId = @artistId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@artistId", artistId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while removing the artist from favorites.", ex);
            }
        }
    }
}