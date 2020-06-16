using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
//using MySQL.Data.EntityFrameworkCore.Extension s;

namespace Zanaetchii.DbContext
{
    public class ZanaetchiiDbContext : base("ZanaetchiiContext")
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(@"User Id=root;Host=localhost;Database=Test;");
        }
       
    }
}
}
