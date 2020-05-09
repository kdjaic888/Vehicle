using Microsoft.EntityFrameworkCore;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.DataContext
{
    public class EFDbContext : DbContext
    {
        const string connectionString = "Data Source=DESKTOP-70657L1/SQLEXPRESS;Initial Catalog=vehicleproject;Integrated Security=True;";
        public EFDbContext()
        {
        }

        public EFDbContext(DbContextOptions<EFDbContext> options)
          : base(options)
        {

        }

        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().ToTable("VehicleMake");
            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModel");

            modelBuilder.Entity<VehicleModel>()
                .HasKey(c => new { c.id, c.makeId });
            //base.OnModelCreating(modelBuilder);
        }

    }
}



