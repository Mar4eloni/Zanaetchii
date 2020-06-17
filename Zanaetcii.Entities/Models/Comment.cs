using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class Comment
    {
        [Column("CommentId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CommentId { get; set; }

        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }

        [ForeignKey("WorkGiverId")]
        public WorkGiver WorkGiver { get; set; }

        [ForeignKey("WorkId")]
        [Required]
        public Work Work { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string CommentContent { get; set; }
    }
}
