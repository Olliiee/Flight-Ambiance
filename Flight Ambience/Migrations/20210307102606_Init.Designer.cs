﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Org.Strausshome.FS.CrewSoundsNG.Data;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    [DbContext(typeof(CsContext))]
    [Migration("20210307102606_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatus", b =>
                {
                    b.Property<int>("FlightStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ambiance")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Door")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EngineRun")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FlightAmbiance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FlightStatusName")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("GearDown")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroundSpeed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ingore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("OnGround")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RadioAltitude")
                        .HasColumnType("INTEGER");

                    b.HasKey("FlightStatusId");

                    b.ToTable("FlightStatuses");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.MediaFile", b =>
                {
                    b.Property<int>("MediaFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAmbiance")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMusic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProfileItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MediaFileId");

                    b.HasIndex("ProfileItemId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", b =>
                {
                    b.Property<int>("ProfileItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FlightStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaFileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sequence")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProfileItemId");

                    b.HasIndex("FlightStatusId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileItems");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Setting")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.MediaFile", b =>
                {
                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", null)
                        .WithMany("MediaFile")
                        .HasForeignKey("ProfileItemId");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", b =>
                {
                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatus", "FlightStatus")
                        .WithMany()
                        .HasForeignKey("FlightStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightStatus");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", b =>
                {
                    b.Navigation("MediaFile");
                });
#pragma warning restore 612, 618
        }
    }
}
