using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zanaetcii.Entities.Models
{
    public class ProjectRole : IdentityRole
    {
        public string RoleName { get; set; }
    }
}
