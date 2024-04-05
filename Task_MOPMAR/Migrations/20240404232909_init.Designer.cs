﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_MOPMAR.Models;

#nullable disable

namespace Task_MOPMAR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240404232909_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task_MOPMAR.Models.Center", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GovernorateId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("GovernorateId");

                    b.HasIndex("VillageId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Governorate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Governorates");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Village", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("GovernorateId");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Center", b =>
                {
                    b.HasOne("Task_MOPMAR.Models.Governorate", "Governorate")
                        .WithMany("Centers")
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Employee", b =>
                {
                    b.HasOne("Task_MOPMAR.Models.Center", "Center")
                        .WithMany()
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Task_MOPMAR.Models.Governorate", "Governorate")
                        .WithMany()
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Task_MOPMAR.Models.Village", "Village")
                        .WithMany()
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("Governorate");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Village", b =>
                {
                    b.HasOne("Task_MOPMAR.Models.Center", "Center")
                        .WithMany("Villages")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Task_MOPMAR.Models.Governorate", "Governorate")
                        .WithMany()
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Center", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("Task_MOPMAR.Models.Governorate", b =>
                {
                    b.Navigation("Centers");
                });
#pragma warning restore 612, 618
        }
    }
}
