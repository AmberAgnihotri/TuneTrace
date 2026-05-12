using Microsoft.Data.SqlClient;
using DAL.DTO;
using Microsoft.Extensions.Configuration;

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

        public List<AlbumDto> GetAll()
        {
            var albums = new List<AlbumDto>();

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

        public AlbumDto? GetById(int id)
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

            if (!reader.Read())
                return null;

            var albumId = (int)reader["id"];
            var title = reader["Title"].ToString() ?? "";
            var releaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
            var artist = reader["Artist"].ToString() ?? "";
            reader.Close();

            var songs = new List<SongDto>();
            using var songCmd = new SqlCommand(@"
                SELECT id, album_id, Title, releaseDate, duration
                FROM Song
                WHERE album_id = @albumId", conn);

            songCmd.Parameters.AddWithValue("@albumId", albumId);
            using var songReader = songCmd.ExecuteReader();

            while (songReader.Read())
            {
                songs.Add(new SongDto(
                    id: (int)songReader["id"],
                    albumId: (int)songReader["album_id"],
                    title: songReader["Title"].ToString() ?? "",
                    artist: "",
                    album: title,
                    releaseDate: songReader["releaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)songReader["releaseDate"],
                    duration: songReader["duration"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)songReader["duration"]
                ));
            }

            return new AlbumDto(albumId, title, releaseDate, artist, 0, songs);
        }

        public List<AlbumDto> Search(string query)
        {
            var albums = new List<AlbumDto>();

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

        public void AddFavorite(int userId, int albumId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO UserAlbum (UserId, AlbumId) VALUES (@userId, @albumId)", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void RemoveFavorite(int userId, int albumId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM UserAlbum WHERE UserId = @userId AND AlbumId = @albumId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@albumId", albumId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private static AlbumDto MapAlbum(SqlDataReader reader)
        {
            return new AlbumDto(
                id: (int)reader["id"],
                title: reader["Title"].ToString() ?? "",
                releaseDate: reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"],
                artist: reader["Artist"].ToString() ?? "",
                artistId: 0,
                songs: new List<SongDto>()
            );
        }
    }
}