using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeoSchool.Models;

namespace NeoSchool.Data
{
    public class NeoSchoolDbContext : IdentityDbContext<User, UserRole, string>
    {
        public DbSet<VideoLesson> VideoLessons { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public NeoSchoolDbContext(DbContextOptions<NeoSchoolDbContext> options) : base(options)
        {
        }

        public NeoSchoolDbContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasKey(user => user.Id);

            base.OnModelCreating(builder);
        }
    }
}
