using ExploreCalifornia.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExploreCalifornia.Entities
{
    public sealed class BlogDataContext : DbContext
    {
        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BlogPost> Posts { get; set; }

        public IEnumerable<MonthlySpecial> MonthlySpecials
        {
            get
            {
                return new[]
                {
                    new MonthlySpecial
                    {
                        Key = "calm",
                        Name = "California Calm Package",
                        Type = "Say Spa Package",
                        Price = 250
                    },
                    new MonthlySpecial
                    {
                        Key = "desert",
                        Name = "From Desert to Sea",
                        Type = "2 Day Salton Sea",
                        Price = 350
                    },
                    new MonthlySpecial
                    {
                        Key = "backpack",
                        Name = "Backpack Cali",
                        Type = "Big Sur Retreat",
                        Price = 250
                    }
                };
            }
        }
    }
}
