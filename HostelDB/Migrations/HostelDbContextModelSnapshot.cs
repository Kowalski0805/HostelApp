﻿// <auto-generated />
using System;
using HostelDB.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HostelDB.Migrations
{
    [DbContext(typeof(HostelDbContext))]
    partial class HostelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HostelDB.Database.Models.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Resident unique identifier.")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasComment("Resident birthday.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Resident name.");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Resident patronymic.");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Resident surname.");

                    b.HasKey("Id")
                        .HasName("PK_Residents_Id");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Residents_Id");

                    b.HasIndex("Surname", "Name", "Patronymic")
                        .HasDatabaseName("I_Residents_Surname_Name_Patronymic");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("HostelDB.Database.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Room unique identifier.")
                        .UseIdentityColumn();

                    b.Property<int>("Floor")
                        .HasColumnType("int")
                        .HasComment("Floor number.");

                    b.Property<int>("MaxResidentsCount")
                        .HasColumnType("int")
                        .HasComment("Maximum number of residents in a room.");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasComment("Room number.");

                    b.HasKey("Id")
                        .HasName("PK_Rooms_Id");

                    b.HasAlternateKey("Floor", "Number");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Rooms_Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HostelDB.Database.Models.RoomResident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Room and resident connection unique identifier.")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EvictDate")
                        .HasColumnType("datetime2")
                        .HasComment("Resident's evicting date.");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int")
                        .HasComment("Resident unique identifier.");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasComment("Room unique identifier.");

                    b.Property<DateTime>("SettleDate")
                        .HasColumnType("datetime2")
                        .HasComment("Resident's settle date.");

                    b.HasKey("Id")
                        .HasName("PK_RoomResidents_Id");

                    b.HasIndex("EvictDate")
                        .HasDatabaseName("I_RoomResidents_EvictDate");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_RoomResidents_Id");

                    b.HasIndex("ResidentId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SettleDate")
                        .HasDatabaseName("I_RoomResidents_SettleDate");

                    b.ToTable("RoomResidents");
                });

            modelBuilder.Entity("HostelDB.Database.Models.RoomResident", b =>
                {
                    b.HasOne("HostelDB.Database.Models.Resident", "Resident")
                        .WithMany("RoomResidents")
                        .HasForeignKey("ResidentId")
                        .HasConstraintName("FK_RoomResidents_ResidentId_Residents_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HostelDB.Database.Models.Room", "Room")
                        .WithMany("RoomResidents")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_RoomResidents_RoomId_Rooms_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resident");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HostelDB.Database.Models.Resident", b =>
                {
                    b.Navigation("RoomResidents");
                });

            modelBuilder.Entity("HostelDB.Database.Models.Room", b =>
                {
                    b.Navigation("RoomResidents");
                });
#pragma warning restore 612, 618
        }
    }
}
