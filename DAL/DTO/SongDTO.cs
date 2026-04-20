using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTOs
{
    public class SongDto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
    }