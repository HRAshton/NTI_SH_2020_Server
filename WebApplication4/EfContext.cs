using System;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models.StorageModels;

namespace WebApplication4
{
    public sealed class EfContext : DbContext
    {
        public EfContext(DbContextOptions options)
            : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public DbSet<HouseTeamModel> Houses { get; set; }

        public DbSet<LogEntity> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntity>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}