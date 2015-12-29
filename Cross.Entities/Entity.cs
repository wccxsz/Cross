using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.Entities
{
    [NotMapped]
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
