using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class WorkField
    {
        [Column("WorkFieldId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkFieldId { get; set; }

        public string Name { get; set; }
    }
}
