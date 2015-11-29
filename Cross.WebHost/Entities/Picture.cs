using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.WebHost.Entities
{
    public class Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureId { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public virtual Album Album { get; set; }
    }
}
