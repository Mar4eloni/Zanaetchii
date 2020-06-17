using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zanaetcii.Entities.Models;

namespace Zanaetcii.Entities.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.HasRequired(t => t.Person)
            //    .WithMany(t => t.DriverLicenses)
            //    .HasForeignKey(d => d.PersonId);


            modelBuilder.Entity<Comment>()
                .HasOne(w => w.Work)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Work>()
                .HasMany(c => c.Comments)
                .WithOne()
                .HasForeignKey(c=>c.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Work> Jobs { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkField> WorkeFields { get; set; }
        public DbSet<WorkGiver> WorkGivers { get; set; }
       // public DbSet<ProjectRole> ProjectRoles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Application>().ToTable("Application");
        //    //modelBuilder.Entity<Comment>().ToTable("Comment");
        //    //modelBuilder.Entity<Rating>().ToTable("Rating");
        //}
    }
}
