using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Bilge_Adam_Core_Project.Dal.Concreate
{
    public class BilgeAdamCoreProjectContext : DbContext
    {
        public BilgeAdamCoreProjectContext(DbContextOptions<BilgeAdamCoreProjectContext> options)
     : base(options)
        { }
        public BilgeAdamCoreProjectContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=remotemysql.com;Port=3306;database=xqRoJ1FKnq;user=xqRoJ1FKnq;password=HqmmsZR20c");
        }
         public DbSet<Director> Director { get; set; }
         public DbSet<DirectorMovies> DirectorMovies { get; set; }
         public DbSet<Movie> Movie { get; set; }
         public DbSet<User> User { get; set; }
         public DbSet<Fav_Watch_List> List { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectorMovies>()
          .HasKey(dm =>dm.Id);

            modelBuilder.Entity<DirectorMovies>()
                .HasOne(dm => dm.Movie)
                .WithMany(m => m.Directors)
                .HasForeignKey(dm => dm.MovieId);

            modelBuilder.Entity<DirectorMovies>()
                .HasOne(dm => dm.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(dm => dm.DirectorId);


            modelBuilder.Entity<Fav_Watch_List>()
          .HasKey(fwl => fwl.Id);

            modelBuilder.Entity<Fav_Watch_List>()
                .HasOne(dm => dm.User)
                .WithMany(m => m.Fav_Watch_List)
                .HasForeignKey(dm => dm.UserId);

            modelBuilder.Entity<Fav_Watch_List>()
                .HasOne(dm => dm.Movie)
                .WithMany(d => d.Fav_Watch_List)
                .HasForeignKey(dm => dm.MovieId);
        }   

    }
}