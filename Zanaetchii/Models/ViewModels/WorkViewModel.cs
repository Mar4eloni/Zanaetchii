using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Models.ViewModels
{
    public class WorkViewModel
    {
        
        public  WorkField WorkField { get; set; }

        
        public WorkGiver WorkGiver { get; set; }


        public  ICollection<Comment> Comments { get; set; }

        
        public  Worker Worker { get; set; }

        
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
    }
}
