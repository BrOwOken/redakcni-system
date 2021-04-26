using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedakcniSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedakcniSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<MenuItem> ArticleMenuItems { get; set; }
        public DbSet<CustomSite> CustomSites { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
