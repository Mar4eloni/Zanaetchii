using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zanaetcii.Entities.Models
{
    public class Worker 
    {
        [Column("WorkerId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("WorkfieldId")]
        public virtual WorkField Workfield { get; set; }
    }
}
