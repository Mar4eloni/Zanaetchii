using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class Application
    {
        [Column("ApplicationId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ApplicationId { get; set; }

        [ForeignKey("WorkId")]
        public virtual Work Work { get; set; }

        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }

    }
}
