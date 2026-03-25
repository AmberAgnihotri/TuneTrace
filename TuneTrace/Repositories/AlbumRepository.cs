using Microsoft.Data.SqlClient;
using TuneTrace.Models;

namespace TuneTrace.Repositories
{
    public class AlbumRepository
    {
        private readonly string _connectionString = string.Empty;

        public AlbumRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
        }

        public List<Album> GetAlbums()
        {
            var albums = new List<Album>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Album", conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                albums.Add(new Album
                {
                    Id = (int)reader["id"],
                    Titel = reader["titel"].ToString() ?? string.Empty
                });
            }

            return albums;
        }
    }
}