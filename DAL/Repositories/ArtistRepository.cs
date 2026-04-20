using Microsoft.Data.SqlClient;
using DAL.DTOs;
using Microsoft.Extensions.Configuration;

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
            var artists = new List<ArtistDTO>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(BaseQuery, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                artists.Add(MapArtist(reader));
            return artists;
        }

        public ArtistDTO? GetArtistById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(BaseQuery + " WHERE ar.id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            var artist = MapArtist(reader);
            reader.Close();

            // Load albums for this artist
            using var albumCmd = new SqlCommand(@"
                SELECT a.id, a.Title, a.ReleaseDate
                FROM Album a
                JOIN AlbumArtist aa ON a.id = aa.AlbumID
                WHERE aa.ArtistID = @artistId", conn);
            albumCmd.Parameters.AddWithValue("@artistId", id);
            using var albumReader = albumCmd.ExecuteReader();
            while (albumReader.Read())
            {
                artist.Albums.Add(new AlbumDto
                {
                    Id = (int)albumReader["id"],
                    Title = albumReader["Title"].ToString() ?? "",
                    ReleaseDate = albumReader["ReleaseDate"] == DBNull.Value
                        ? DateTime.MinValue
                        : (DateTime)albumReader["ReleaseDate"]
                });
            }

            return artist;
        }

        public List<ArtistDTO> SearchArtists(string query)
        {
            var artists = new List<ArtistDTO>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(BaseQuery + " WHERE ar.Name LIKE @query", conn);
            cmd.Parameters.AddWithValue("@query", "%" + query + "%");
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                artists.Add(MapArtist(reader));
            return artists;
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

        private ArtistDTO MapArtist(SqlDataReader reader)
        {
            return new ArtistDTO
            {
                Id = (int)reader["id"],
                Name = reader["Name"].ToString() ?? "",
                Biography = reader["Biography"] == DBNull.Value ? "" : reader["Biography"].ToString() ?? ""
            };
        }
    }
}