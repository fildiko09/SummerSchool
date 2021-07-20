using System;

namespace MusicWebApi.ExternalModels
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid ArtistId { get; set; }

        public ArtistDTO Artist { get; set; }
    }
}
