using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicWebApi.Entities
{
    public class Song
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Lyrics { get; set; }

        [Required]
        public Guid AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

        public bool? Deleted { get; set; }
    }
}
