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
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthPlace");

                    b.Property<DateTime>("DateOfAdd");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Director");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.DirectorMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfAdd");

                    b.Property<int>("DirectorId");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("DirectorMovies");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Fav_Watch_List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfAdd");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("ListType")
                        .IsRequired();

                    b.Property<int>("MovieId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("List");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfAdd");

                    b.Property<string>("Duration");

                    b.Property<string>("Genre");

                    b.Property<double>("ImdbRating");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfAdd");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Mail")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.DirectorMovies", b =>
                {
                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bilge_Adam_Core_Project.Model.Models.Fav_Watch_List", b =>
                {
                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.Movie", "Movie")
                        .WithMany("Fav_Watch_List")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bilge_Adam_Core_Project.Model.Models.User", "User")
                        .WithMany("Fav_Watch_List")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
