using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LFHDBContext : DbContext
    {
        public LFHDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }

        public DbSet<CarouselN> Carousel { get; set; }

        public DbSet<TravelCard> Travelcard { get; set; }

        public DbSet<UserRegistration> Users { get; set; }


        public DbSet<VisitorsCountModel> Visitors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegistration>().Ignore(u => u.Message);
            modelBuilder.Entity<UserLogin>().Ignore(u => u.Message);
            modelBuilder.Entity<UserLogin>().HasNoKey();

        }


    }
}
