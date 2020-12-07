using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zanaetcii.Entities.Models;

namespace Zanaetcii.Entities.Context
{
    public class UserDbContext : IdentityDbContext<Users, ProjectRole, string>
    {
        public UserDbContext() { }
        public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
        { }
    }
}
