﻿// <auto-generated />
using System;
using Infra.Data.Efcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230805175552_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CategoryMovie");
                });

            modelBuilder.Entity("Domain.Entities.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToTable("Entity", t =>
                        {
                            t.Property("Name")
                                .HasColumnName("Category_Name");
                        });

                    b.HasDiscriminator().HasValue("Category");
                });

            modelBuilder.Entity("Domain.Entities.Chair", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("RoomId");

                    b.HasDiscriminator().HasValue("Chair");
                });

            modelBuilder.Entity("Domain.Entities.Cinema", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasDiscriminator().HasValue("Cinema");
                });

            modelBuilder.Entity("Domain.Entities.Movie", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float>("Stars")
                        .HasColumnType("real");

                    b.ToTable("Entity", t =>
                        {
                            t.Property("Name")
                                .HasColumnName("Movie_Name");
                        });

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<Guid?>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasIndex("CinemaId");

                    b.ToTable("Entity", t =>
                        {
                            t.Property("Number")
                                .HasColumnName("Room_Number");
                        });

                    b.HasDiscriminator().HasValue("Room");
                });

            modelBuilder.Entity("Domain.Entities.Session", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Entity", t =>
                        {
                            t.Property("RoomId")
                                .HasColumnName("Session_RoomId");
                        });

                    b.HasDiscriminator().HasValue("Session");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<Guid?>("ChairId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserOwnId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ChairId");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserOwnId");

                    b.HasDiscriminator().HasValue("Ticket");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasBaseType("Domain.Entities.Entity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.HasOne("Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Chair", b =>
                {
                    b.HasOne("Domain.Entities.Room", "Room")
                        .WithMany("Chairs")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.HasOne("Domain.Entities.Cinema", "Cinema")
                        .WithMany("Rooms")
                        .HasForeignKey("CinemaId");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Domain.Entities.Session", b =>
                {
                    b.HasOne("Domain.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Domain.Entities.Room", "Room")
                        .WithMany("Sessions")
                        .HasForeignKey("RoomId");

                    b.OwnsOne("Domain.Entities.Interval", "Interval", b1 =>
                        {
                            b1.Property<Guid>("SessionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<TimeSpan?>("End")
                                .HasColumnType("time")
                                .HasColumnName("End");

                            b1.Property<TimeSpan?>("Start")
                                .HasColumnType("time")
                                .HasColumnName("Start");

                            b1.HasKey("SessionId");

                            b1.ToTable("Entity");

                            b1.WithOwner()
                                .HasForeignKey("SessionId");
                        });

                    b.Navigation("Interval");

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Chair", "Chair")
                        .WithMany()
                        .HasForeignKey("ChairId");

                    b.HasOne("Domain.Entities.Session", "Session")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionId");

                    b.HasOne("Domain.Entities.User", "UserOwn")
                        .WithMany("Tickets")
                        .HasForeignKey("UserOwnId");

                    b.Navigation("Chair");

                    b.Navigation("Session");

                    b.Navigation("UserOwn");
                });

            modelBuilder.Entity("Domain.Entities.Cinema", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Navigation("Chairs");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Domain.Entities.Session", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
