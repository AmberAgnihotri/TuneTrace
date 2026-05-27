using Microsoft.Data.SqlClient;
using DAL.DTO;
using Microsoft.Extensions.Configuration;
using Interfaces.Interfaces;

namespace DAL.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly string _connectionString;

        public AlbumRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string")
                                ?? string.Empty;
        }

        public List<AlbumDTO> GetAll()
        {
            try
            {
                var albums = new List<AlbumDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT a.id, a.Title, a.ReleaseDate, ar.Name AS Artist
                    FROM Album a
                    LEFT JOIN AlbumArtist aa ON a.id = aa.AlbumID
                    LEFT JOIN Artist ar ON aa.ArtistID = ar.id", conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    albums.Add(MapAlbum(reader));
                return albums;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong with fetching albums", ex);
            }
        }

        public AlbumDTO? GetById(int id)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT a.id, a.Title, a.ReleaseDate, ar.Name AS Artist
                    FROM Album a
                    LEFT JOIN AlbumArtist aa ON a.id = aa.AlbumID
                    LEFT JOIN Artist ar ON aa.ArtistID = ar.id
                    WHERE a.id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                var albumId = (int)reader["id"];
                var title = reader["Title"].ToString() ?? "";
                var releaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                var artist = reader["Artist"].ToString() ?? "";
                reader.Close();
                var songs = new List<SongDTO>();
                using var songCmd = new SqlCommand(@"
                    SELECT id, album_id, Title, releaseDate, duration
                    FROM Song
                    WHERE album_id = @albumId", conn);
                songCmd.Parameters.AddWithValue("@albumId", albumId);
                using var songReader = songCmd.ExecuteReader();
                while (songReader.Read())
                {
                    songs.Add(new SongDTO(
                        id: (int)songReader["id"],
                        albumId: (int)songReader["album_id"],
                        title: songReader["Title"].ToString() ?? "",
                        artist: "",
                        album: title,
                        releaseDate: songReader["releaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)songReader["releaseDate"],
                        duration: songReader["duration"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)songReader["duration"]
                    ));
                }
                return new AlbumDTO(albumId, title, releaseDate, artist, 0, songs);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong with fetching the album", ex);
            }
        }

        public List<AlbumDTO> Search(string query)
        {
            try
            {
                var albums = new List<AlbumDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(@"
                    SELECT a.id, a.Title, a.ReleaseDate, ar.Name AS Artist
                    FROM Album a
                    LEFT JOIN AlbumArtist aa ON a.id = aa.AlbumID
                    LEFT JOIN Artist ar ON aa.ArtistID = ar.id
                    WHERE a.Title LIKE @query
                    OR SOUNDEX(a.Title) = SOUNDEX(@exactQuery)", conn);
                cmd.Parameters.AddWithValue("@query", "%" + query + "%");
                cmd.Parameters.AddWithValue("@exactQuery", query);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    albums.Add(MapAlbum(reader));
                return albums;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong with searching albums", ex);
            }
        }

        public bool IsFavorite(int userId, int albumId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM UserAlbum WHERE UserId = @userId AND AlbumId = @albumId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong with checking favourites", ex);
            }
        }

        public void AddFavorite(int userId, int albumId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "INSERT INTO UserAlbum (UserId, AlbumId) VALUES (@userId, @albumId)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong with adding to favourites", ex);
            }
        }

        public void RemoveFavorite(int userId, int albumId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "DELETE FROM UserAlbum WHERE UserId = @userId AND AlbumId = @albumId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@albumId", albumId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong with removing from favourites", ex);
            }
        }

        private static AlbumDTO MapAlbum(SqlDataReader reader)
        {
            return new AlbumDTO(
                id: (int)reader["id"],
                title: reader["Title"].ToString() ?? "",
                releaseDate: reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"],
                artist: reader["Artist"].ToString() ?? "",
                artistId: 0,
                songs: new List<SongDTO>()
            );
        }
    }
}