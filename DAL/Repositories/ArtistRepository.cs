using Microsoft.Data.SqlClient;
using DAL.DTO;
using Microsoft.Extensions.Configuration;
using Interfaces.Interfaces;

namespace DAL.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly string _connectionString;

        public ArtistRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string")
                                ?? string.Empty;
        }

        private const string BaseQuery = @"
            SELECT ar.id, ar.Name AS Name, ar.biography AS Biography
            FROM Artist ar";

        public List<ArtistDTO> GetArtists()
        {
            try
            {
                var artists = new List<ArtistDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(BaseQuery, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    artists.Add(MapArtist(reader));
                return artists;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the artists.", ex);
            }
        }

        public ArtistDTO? GetArtistById(int id)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(BaseQuery + " WHERE ar.id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;

                var artistId = (int)reader["id"];
                var name = reader["Name"].ToString() ?? "";
                var biography = reader["Biography"] == DBNull.Value ? "" : reader["Biography"].ToString() ?? "";
                reader.Close();

                var albums = new List<AlbumDto>();
                using (var albumConn = new SqlConnection(_connectionString))
                {
                    albumConn.Open();
                    using var albumCmd = new SqlCommand(@"
                        SELECT a.id, a.Title, a.ReleaseDate
                        FROM Album a
                        JOIN AlbumArtist aa ON a.id = aa.AlbumID
                        WHERE aa.ArtistID = @artistId", albumConn);
                    albumCmd.Parameters.AddWithValue("@artistId", artistId);
                    using var albumReader = albumCmd.ExecuteReader();
                    while (albumReader.Read())
                    {
                        albums.Add(new AlbumDto(
                            id: (int)albumReader["id"],
                            title: albumReader["Title"].ToString() ?? "",
                            releaseDate: albumReader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)albumReader["ReleaseDate"],
                            artist: name,
                            artistId: artistId,
                            songs: new List<SongDto>()
                        ));
                    }
                }

                var songs = new List<SongDto>();
                using (var songConn = new SqlConnection(_connectionString))
                {
                    songConn.Open();
                    using var songCmd = new SqlCommand(@"
                        SELECT s.id, s.Title, s.releaseDate, ISNULL(s.duration, '00:00:00') AS duration
                        FROM Song s
                        JOIN Album a ON s.album_id = a.id
                        JOIN AlbumArtist aa ON a.id = aa.AlbumID
                        WHERE aa.ArtistID = @artistId", songConn);
                    songCmd.Parameters.AddWithValue("@artistId", artistId);
                    using var songReader = songCmd.ExecuteReader();
                    while (songReader.Read())
                    {
                        songs.Add(new SongDto(
                            id: (int)songReader["id"],
                            albumId: 0,
                            title: songReader["Title"].ToString() ?? "",
                            artist: name,
                            album: "",
                            releaseDate: songReader["releaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)songReader["releaseDate"],
                            duration: (TimeSpan)songReader["duration"]
                        ));
                    }
                }

                return new ArtistDTO(artistId, name, biography, albums, songs);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while retrieving the artist.", ex);
            }
        }

        public List<ArtistDTO> SearchArtists(string query)
        {
            try
            {
                var artists = new List<ArtistDTO>();
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(BaseQuery + @" WHERE ar.Name LIKE @query
                    OR SOUNDEX(ar.Name) = SOUNDEX(@exactQuery)", conn);
                cmd.Parameters.AddWithValue("@query", "%" + query + "%");
                cmd.Parameters.AddWithValue("@exactQuery", query);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    artists.Add(MapArtist(reader));
                return artists;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while searching for artists.", ex);
            }
        }

        public void AddFavoriteArtist(int userId, int artistId)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(
                    "INSERT INTO UserArtist (UserId, ArtistId) VALUES (@userId, @artistId)", conn);
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
                using var cmd = new SqlCommand(
                    "DELETE FROM UserArtist WHERE UserId = @userId AND ArtistId = @artistId", conn);
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

        private static ArtistDTO MapArtist(SqlDataReader reader)
        {
            return new ArtistDTO(
                id: (int)reader["id"],
                name: reader["Name"].ToString() ?? "",
                biography: reader["Biography"] == DBNull.Value ? "" : reader["Biography"].ToString() ?? "",
                albums: new List<AlbumDto>(),
                songs: new List<SongDto>()
            );
        }
    }
}