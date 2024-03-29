﻿// <auto-generated />
using System;
using Bilge_Adam_Core_Project.Dal.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bilge_Adam_Core_Project.Dal.Migrations
{
    [DbContext(typeof(BilgeAdamCoreProjectContext))]
    partial class BilgeAdamCoreProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Director");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.DirectorMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("DirectorMovies");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Fav_Watch_List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ListType")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("List");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Duration")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Genre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("ImdbRating")
                        .HasColumnType("double");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.DirectorMovies", b =>
                {
                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Fav_Watch_List", b =>
                {
                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.Movie", "Movie")
                        .WithMany("Fav_Watch_List")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.User", "User")
                        .WithMany("Fav_Watch_List")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
