using Microsoft.Data.SqlClient;
using TuneTrace.Models;

namespace TuneTrace.Repositories
{
    public class BeoordelingRepository
    {
        private readonly string _connectionString = string.Empty;

        public BeoordelingRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSQL connection string") ?? string.Empty;
        }

        public void VoegBeoordelingToe(int gebruikerId, int? albumId, int? songId, int rating, string review)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO Beoordeling (gebruiker_id, album_id, song_id, rating, review) VALUES (@gebruikerId, @albumId, @songId, @rating, @review)", conn);
            cmd.Parameters.AddWithValue("@gebruikerId", gebruikerId);
            cmd.Parameters.AddWithValue("@albumId", (object?)albumId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@songId", (object?)songId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@review", review);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public bool HeeftActieveBeoordeling(int gebruikerId, int? albumId, int? songId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                @"SELECT COUNT(*) FROM Beoordeling 
                  WHERE gebruiker_id = @gebruikerId 
                  AND (album_id = @albumId OR (album_id IS NULL AND @albumId IS NULL))
                  AND (song_id = @songId OR (song_id IS NULL AND @songId IS NULL))", conn);
            cmd.Parameters.AddWithValue("@gebruikerId", gebruikerId);
            cmd.Parameters.AddWithValue("@albumId", (object?)albumId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@songId", (object?)songId ?? DBNull.Value);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public List<Beoordeling> GetBeoordelingenVanGebruiker(int gebruikerId)
        {
            var beoordelingen = new List<Beoordeling>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                @"SELECT b.id, b.rating, b.review, b.album_id, b.song_id,
                  a.titel as album_titel, s.titel as song_titel
                  FROM Beoordeling b
                  LEFT JOIN Album a ON b.album_id = a.id
                  LEFT JOIN Song s ON b.song_id = s.id
                  WHERE b.gebruiker_id = @gebruikerId", conn);
            cmd.Parameters.AddWithValue("@gebruikerId", gebruikerId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                beoordelingen.Add(new Beoordeling
                {
                    Id = (int)reader["id"],
                    Rating = (int)reader["rating"],
                    Review = reader["review"] == DBNull.Value ? string.Empty : reader["review"].ToString() ?? string.Empty,
                    Album = reader["album_id"] == DBNull.Value ? null : new Album { Id = (int)reader["album_id"], Titel = reader["album_titel"].ToString() ?? string.Empty },
                    Song = reader["song_id"] == DBNull.Value ? null : new Song { Id = (int)reader["song_id"], Titel = reader["song_titel"].ToString() ?? string.Empty }
                });
            }
            return beoordelingen;
        }

        public void VerwijderBeoordelingOpId(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM Beoordeling WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}