using System;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApi.Entities
{
    public class Artist
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public bool? Deleted { get; set; }
    }
}
