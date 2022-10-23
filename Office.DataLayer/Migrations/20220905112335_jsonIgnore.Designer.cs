﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Office.DataLayer.Context;

namespace Office.DataLayer.Migrations
{
    [DbContext(typeof(OrganazationDbContext))]
    [Migration("20220905112335_jsonIgnore")]
    partial class jsonIgnore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Office.DataLayer.Models.ChildOfPerosnnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChildGender")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonnelId");

                    b.ToTable("Childern");
                });

            modelBuilder.Entity("Office.DataLayer.Models.Organazation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ParrentOfficeId")
                        .HasColumnType("int");

                    b.Property<int>("PersonnelMainOfficeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Organzations");
                });

            modelBuilder.Entity("Office.DataLayer.Models.Permission", b =>
                {
                    b.Property<int>("OrganzationId")
                        .HasColumnType("int");

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.HasKey("OrganzationId", "PersonnelId");

                    b.HasIndex("PersonnelId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Office.DataLayer.Models.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("PersonnelGender")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationalCode")
                        .IsUnique();

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("Office.DataLayer.Models.PersonnelMainOffice", b =>
                {
                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<int>("OrganzationId")
                        .HasColumnType("int");

                    b.HasKey("PersonnelId", "OrganzationId");

                    b.HasIndex("OrganzationId")
                        .IsUnique();

                    b.HasIndex("PersonnelId")
                        .IsUnique();

                    b.ToTable("PersonnelMainOffices");
                });

            modelBuilder.Entity("Office.DataLayer.Models.ChildOfPerosnnel", b =>
                {
                    b.HasOne("Office.DataLayer.Models.Personnel", "Personnel")
                        .WithMany()
                        .HasForeignKey("PersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personnel");
                });

            modelBuilder.Entity("Office.DataLayer.Models.Permission", b =>
                {
                    b.HasOne("Office.DataLayer.Models.Organazation", "Organiation")
                        .WithMany("Permissions")
                        .HasForeignKey("OrganzationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Office.DataLayer.Models.Personnel", "Personnel")
                        .WithMany("Permissions")
                        .HasForeignKey("PersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organiation");

                    b.Navigation("Personnel");
                });

            modelBuilder.Entity("Office.DataLayer.Models.PersonnelMainOffice", b =>
                {
                    b.HasOne("Office.DataLayer.Models.Organazation", "Organiation")
                        .WithOne("PerosnnelMainOffice")
                        .HasForeignKey("Office.DataLayer.Models.PersonnelMainOffice", "OrganzationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Office.DataLayer.Models.Personnel", "Personnel")
                        .WithOne("PerosnnelMainOffice")
                        .HasForeignKey("Office.DataLayer.Models.PersonnelMainOffice", "PersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organiation");

                    b.Navigation("Personnel");
                });

            modelBuilder.Entity("Office.DataLayer.Models.Organazation", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("PerosnnelMainOffice");
                });

            modelBuilder.Entity("Office.DataLayer.Models.Personnel", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("PerosnnelMainOffice");
                });
#pragma warning restore 612, 618
        }
    }
}