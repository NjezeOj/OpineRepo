using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Opine.Server.Entities;
using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Server
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Voted> Votes { get; set; }
    }
}
