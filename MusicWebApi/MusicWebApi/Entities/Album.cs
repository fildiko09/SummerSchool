using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicWebApi.Entities
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }

        public bool? Deleted { get; set; }
    }
}
