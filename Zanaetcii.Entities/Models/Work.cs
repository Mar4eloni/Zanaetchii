using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class Work
    {
        [Column("WorkId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkId { get; set; }


        [ForeignKey("WorkFieldId")]
        public virtual WorkField WorkField { get; set; }

        [ForeignKey("WorkGiverId")]
        public virtual WorkGiver WorkGiver { get; set; }

        [ForeignKey("CommentId")]
        public virtual ICollection<Comment> Comments { get; set; }

        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

    }
}
