using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class WorkGiver
    {
        [Column("WorkGiverId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkGiverId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}
