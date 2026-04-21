using System.Collections.Generic;

namespace DAL.DTOs
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public List<int> AlbumIds { get; set; } = new();
        public List<int> SongIds { get; set; } = new();
        public List<AlbumDto> Albums { get; set; } = new();
        public List<SongDto> Songs { get; set; } = new();
    }
}