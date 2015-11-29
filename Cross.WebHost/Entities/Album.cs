using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.WebHost.Entities
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }

        [MaxLength(255, ErrorMessage = "字符长度超过255")]
        public string AlbumName { get; set; }

        public virtual IList<Picture> Pictures { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Updated { get; set; }

        public ApplicationUser CreateUser { get; set; }
    }
}
