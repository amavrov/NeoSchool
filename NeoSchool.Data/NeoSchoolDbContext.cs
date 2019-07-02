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
        public NeoSchoolDbContext(DbContextOptions<NeoSchoolDbContext> options)
            : base(options)
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
