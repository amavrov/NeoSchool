using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NeoSchool.Data
{
    public class NeoSchoolDbContext : IdentityDbContext
    {
        public NeoSchoolDbContext(DbContextOptions<NeoSchoolDbContext> options)
            : base(options)
        {
        }
    }
}
