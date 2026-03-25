using Microsoft.Data.SqlClient;
using TuneTrace.Models;

namespace TuneTrace.Repositories
{
    public class ZoekRepository
    {
        private readonly string _connectionString = string.Empty;

        public ZoekRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
        }

        public List<Artist> ZoekArtiesten(string zoekterm)
        {
            var resultaten = new List<Artist>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT id, naam FROM Artist WHERE naam LIKE @zoekterm", conn);
            cmd.Parameters.AddWithValue("@zoekterm", $"%{zoekterm}%");
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultaten.Add(new Artist
                {
                    Id = (int)reader["id"],
                    Naam = reader["naam"].ToString() ?? string.Empty
                });
            }
            return resultaten;
        }

        public List<Album> ZoekAlbums(string zoekterm)
        {
            var resultaten = new List<Album>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT id, titel FROM Album WHERE titel LIKE @zoekterm", conn);
            cmd.Parameters.AddWithValue("@zoekterm", $"%{zoekterm}%");
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultaten.Add(new Album
                {
                    Id = (int)reader["id"],
                    Titel = reader["titel"].ToString() ?? string.Empty
                });
            }
            return resultaten;
        }

        public List<Song> ZoekSongs(string zoekterm)
        {
            var resultaten = new List<Song>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT id, titel FROM Song WHERE titel LIKE @zoekterm", conn);
            cmd.Parameters.AddWithValue("@zoekterm", $"%{zoekterm}%");
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultaten.Add(new Song
                {
                    Id = (int)reader["id"],
                    Titel = reader["titel"].ToString() ?? string.Empty
                });
            }
            return resultaten;
        }
    }
}