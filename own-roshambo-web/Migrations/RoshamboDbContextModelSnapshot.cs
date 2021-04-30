﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OwnRoshamboWeb.Repositories;

namespace OwnRoshamboWeb.Migrations
{
    [DbContext(typeof(RoshamboDbContext))]
    partial class RoshamboDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.Connection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Contected")
                        .HasColumnType("bit");

                    b.Property<string>("UserAgent")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("GameOwnerId")
                        .HasColumnType("int");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.GameRoom", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("GameRoom");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john@example.com",
                            IsActive = true,
                            Password = new byte[] { 19, 155, 89, 252, 251, 224, 134, 134, 180, 203, 190, 211, 213, 229, 148, 162, 238, 1, 44, 139 },
                            Score = 0,
                            Username = "John94"
                        },
                        new
                        {
                            Id = 2,
                            Email = "nikolas@example.com",
                            IsActive = true,
                            Password = new byte[] { 246, 94, 140, 123, 33, 34, 100, 48, 243, 80, 232, 2, 91, 130, 233, 89, 216, 214, 222, 15 },
                            Score = 0,
                            Username = "Nikolas89"
                        },
                        new
                        {
                            Id = 3,
                            Email = "tom@example.com",
                            IsActive = true,
                            Password = new byte[] { 55, 104, 210, 145, 241, 90, 122, 189, 215, 92, 231, 53, 83, 15, 43, 64, 88, 135, 64, 45 },
                            Score = 0,
                            Username = "Tom78"
                        },
                        new
                        {
                            Id = 4,
                            Email = "ellena@example.com",
                            IsActive = true,
                            Password = new byte[] { 51, 107, 230, 171, 25, 233, 209, 99, 158, 240, 63, 164, 149, 237, 52, 169, 115, 133, 234, 32 },
                            Score = 0,
                            Username = "Ellena"
                        });
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.Connection", b =>
                {
                    b.HasOne("OwnRoshamboWeb.Repositories.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.Game", b =>
                {
                    b.HasOne("OwnRoshamboWeb.Repositories.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.GameRoom", b =>
                {
                    b.HasOne("OwnRoshamboWeb.Repositories.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OwnRoshamboWeb.Repositories.Models.UserGame", b =>
                {
                    b.HasOne("OwnRoshamboWeb.Repositories.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OwnRoshamboWeb.Repositories.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
