using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class Users
    {
        [Column("UserId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string BankAcc { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int UserType { get; set; }
    }
}
