﻿// <auto-generated />
using System;
using CaptainUnderpantsReviewApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaptainUnderpantsReviewApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240131082002_abc")]
    partial class abc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.CaptainUnderpant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CaptainUnderpants");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.CaptainUnderpantsCategory", b =>
                {
                    b.Property<int>("CaptainUnderpantsId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("CaptainUnderpantsId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CaptainUnderpantsCategories");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.CaptainUnderpantsOwner", b =>
                {
                    b.Property<int>("CaptainUnderpantsId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("CaptainUnderpantsId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("CaptainUnderpantsOwners");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CaptainUnderpantsId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaptainUnderpantsId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.CaptainUnderpantsCategory", b =>
                {
                    b.HasOne("CaptainUnderpantsReviewApp.Models.CaptainUnderpant", "CaptainUnderpants")
                        .WithMany("CaptainUnderpantsCategories")
                        .HasForeignKey("CaptainUnderpantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaptainUnderpantsReviewApp.Models.Category", "Category")
                        .WithMany("CaptainUnderpantsCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaptainUnderpants");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.CaptainUnderpantsOwner", b =>
                {
                    b.HasOne("CaptainUnderpantsReviewApp.Models.CaptainUnderpant", "CaptainUnderpants")
                        .WithMany("CaptainUnderpantsOwners")
                        .HasForeignKey("CaptainUnderpantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaptainUnderpantsReviewApp.Models.Owner", "Owner")
                        .WithMany("CaptainUnderpantsOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaptainUnderpants");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Owner", b =>
                {
                    b.HasOne("CaptainUnderpantsReviewApp.Models.Country", "Country")
                        .WithMany("owners")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Review", b =>
                {
                    b.HasOne("CaptainUnderpantsReviewApp.Models.CaptainUnderpant", "CaptainUnderpants")
                        .WithMany("Reviews")
                        .HasForeignKey("CaptainUnderpantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaptainUnderpantsReviewApp.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaptainUnderpants");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.CaptainUnderpant", b =>
                {
                    b.Navigation("CaptainUnderpantsCategories");

                    b.Navigation("CaptainUnderpantsOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Category", b =>
                {
                    b.Navigation("CaptainUnderpantsCategories");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Country", b =>
                {
                    b.Navigation("owners");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Owner", b =>
                {
                    b.Navigation("CaptainUnderpantsOwners");
                });

            modelBuilder.Entity("CaptainUnderpantsReviewApp.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
