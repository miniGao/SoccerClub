﻿// <auto-generated />
using Li_G_301066253.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Li_G_301066253.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200317184816_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Li_G_301066253.Models.Club", b =>
                {
                    b.Property<int>("ClubID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Information");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("ClubID");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Li_G_301066253.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("ClubID");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("PlayerID");

                    b.HasIndex("ClubID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Li_G_301066253.Models.Player", b =>
                {
                    b.HasOne("Li_G_301066253.Models.Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
