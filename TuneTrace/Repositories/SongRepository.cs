using Microsoft.Data.SqlClient;
using TuneTrace.Models;

namespace TuneTrace.Repositories
{
    public class SongRepository
    {
        private readonly string _connectionString = string.Empty;

        public SongRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
        }

        public List<Song> GetSongs()
        {
            var songs = new List<Song>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Song", conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                songs.Add(new Song
                {
                    Id = (int)reader["id"],
                    Titel = reader["titel"].ToString() ?? string.Empty
                });
            }

            return songs;
        }
    }
}