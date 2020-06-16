using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class Rating
    {
        [Column("RatingId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RatingId { get; set; }


        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }

        [ForeignKey("WorkGiverId")]
        public virtual WorkGiver WorkGiver { get; set; }

        [ForeignKey("WorkId")]
        public virtual Work Work { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float RatingAmmount { get; set; }
    }
}
