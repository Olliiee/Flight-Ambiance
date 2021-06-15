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
    [Migration("20210516140033_MediaFileUpdate3")]
    partial class MediaFileUpdate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatus", b =>
                {
                    b.Property<int>("FlightStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Altitude")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AltitudeOperator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CallGroundServices")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FlightStatusName")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroundSpeed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ignore")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDoorOpen")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEngineRun")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGearDown")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOnGround")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ParkingBrakeSet")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RadioAltitude")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RadioOperator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SeatbeltsSignOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sequence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeedOperator")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VerticalOperator")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VerticalSpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("FlightStatusId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FlightStatuses");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatusProfile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ProfileId");

                    b.ToTable("FlightStatusProfiles");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.MediaFile", b =>
                {
                    b.Property<int>("MediaFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProfileItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
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

                    b.Property<int?>("FlightProfileProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ProfileId");

                    b.HasIndex("FlightProfileProfileId");

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

                    b.Property<int>("Setting")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatus", b =>
                {
                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatusProfile", "Profile")
                        .WithMany("FlightStatus")
                        .HasForeignKey("ProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.MediaFile", b =>
                {
                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", null)
                        .WithMany("MediaFile")
                        .HasForeignKey("ProfileItemId");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.Profile", b =>
                {
                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatusProfile", "FlightProfile")
                        .WithMany()
                        .HasForeignKey("FlightProfileProfileId");

                    b.Navigation("FlightProfile");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", b =>
                {
                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatus", "FlightStatus")
                        .WithMany()
                        .HasForeignKey("FlightStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Org.Strausshome.FS.CrewSoundsNG.Models.Profile", "Profile")
                        .WithMany("ProfileItems")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightStatus");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.FlightStatusProfile", b =>
                {
                    b.Navigation("FlightStatus");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.Profile", b =>
                {
                    b.Navigation("ProfileItems");
                });

            modelBuilder.Entity("Org.Strausshome.FS.CrewSoundsNG.Models.ProfileItem", b =>
                {
                    b.Navigation("MediaFile");
                });
#pragma warning restore 612, 618
        }
    }
}
