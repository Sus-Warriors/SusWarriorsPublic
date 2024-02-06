﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SusWarriors.Infrastructure.Data;

#nullable disable

namespace SusWarriors.Infrastructure.Migrations
{
    [DbContext(typeof(HealthDbContext))]
    [Migration("20240128074004_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SusWarriors.Core.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.DoctorAggregate.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.DoctorAggregate.DoctorScoring", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MedicineCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorScoring");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.DoctorAggregate.PrescribedMedItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Dosage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MedItemWithCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("PrescribedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("PrescribedMedItem");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.MedItemAggregate.MedItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EmissionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmissionsId");

                    b.HasIndex("RatingId");

                    b.ToTable("MedItem");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.MedItemAggregate.MedItemEmissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("EmissionValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MedicineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MedItemEmissions");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.MedItemAggregate.MedItemRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("MedicineCatId")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MedicineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MedItemRating");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.MedItemAggregate.MedItemWithCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("MedItemCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MedItemWithCategory");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.MedItemCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MedItemCategory");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.PatientAggregate.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTimeUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentifierNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.DoctorAggregate.DoctorScoring", b =>
                {
                    b.HasOne("SusWarriors.Core.Models.DoctorAggregate.Doctor", null)
                        .WithMany("DoctorScorings")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SusWarriors.Core.ValueObjects.DateTimeOffsetRange", "Period", b1 =>
                        {
                            b1.Property<Guid>("DoctorScoringId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("End")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("Start")
                                .HasColumnType("datetimeoffset");

                            b1.HasKey("DoctorScoringId");

                            b1.ToTable("DoctorScoring");

                            b1.WithOwner()
                                .HasForeignKey("DoctorScoringId");
                        });

                    b.Navigation("Period")
                        .IsRequired();
                });

            modelBuilder.Entity("SusWarriors.Core.Models.DoctorAggregate.PrescribedMedItem", b =>
                {
                    b.HasOne("SusWarriors.Core.Models.DoctorAggregate.Doctor", null)
                        .WithMany("PrescribedMedItems")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SusWarriors.Core.Models.MedItemAggregate.MedItem", b =>
                {
                    b.HasOne("SusWarriors.Core.Models.MedItemAggregate.MedItemEmissions", "Emissions")
                        .WithMany()
                        .HasForeignKey("EmissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SusWarriors.Core.Models.MedItemAggregate.MedItemRating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emissions");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("SusWarriors.Core.Models.DoctorAggregate.Doctor", b =>
                {
                    b.Navigation("DoctorScorings");

                    b.Navigation("PrescribedMedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
