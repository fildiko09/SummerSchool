using System;

namespace MusicWebApi.ExternalModels
{
    public class SongDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Lyrics { get; set; }

        public Guid AlbumId { get; set; }

        public AlbumDTO Album { get; set; }
    }
}
