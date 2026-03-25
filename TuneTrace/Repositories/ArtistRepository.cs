using Microsoft.Data.SqlClient;
using TuneTrace.Models;

namespace TuneTrace.Repositories
{
    public class ArtistRepository
    {
        private readonly string _connectionString = string.Empty;

        public ArtistRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
        }

        public List<Artist> GetArtists()
        {
            var artists = new List<Artist>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Artist", conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                artists.Add(new Artist
                {
                    Naam = reader["naam"].ToString() ?? string.Empty
                });
            }

            return artists;
        }
    }
}