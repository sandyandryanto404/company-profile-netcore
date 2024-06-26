﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArticleReference", b =>
                {
                    b.Property<long>("ArticlesId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReferencesId")
                        .HasColumnType("bigint");

                    b.HasKey("ArticlesId", "ReferencesId");

                    b.HasIndex("ReferencesId");

                    b.ToTable("ArticleReference");
                });

            modelBuilder.Entity("backend.Models.Entities.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Slug");

                    b.HasIndex("Status");

                    b.HasIndex("Title");

                    b.HasIndex("UpdatedAt");

                    b.HasIndex("UserId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("backend.Models.Entities.ArticleComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("ParentId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedAt");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleComment");
                });

            modelBuilder.Entity("backend.Models.Entities.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Email");

                    b.HasIndex("Name");

                    b.HasIndex("Status");

                    b.HasIndex("Subject");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("backend.Models.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Address");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Email");

                    b.HasIndex("Image");

                    b.HasIndex("Name");

                    b.HasIndex("Phone");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("backend.Models.Entities.Faq", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Sort")
                        .HasColumnType("int4");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Question");

                    b.HasIndex("Sort");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Faq");
                });

            modelBuilder.Entity("backend.Models.Entities.Portfolio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProjectDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProjectUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("ReferenceId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sort")
                        .HasColumnType("int4");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProjectDate");

                    b.HasIndex("ProjectUrl");

                    b.HasIndex("ReferenceId");

                    b.HasIndex("Sort");

                    b.HasIndex("Status");

                    b.HasIndex("Title");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("backend.Models.Entities.PortfolioImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<long>("PortfolioId")
                        .HasColumnType("bigint");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Image");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("PortfolioImage");
                });

            modelBuilder.Entity("backend.Models.Entities.Reference", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<int>("Type")
                        .HasColumnType("int4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Name");

                    b.HasIndex("Slug");

                    b.HasIndex("Status");

                    b.HasIndex("Type");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("backend.Models.Entities.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Sort")
                        .HasColumnType("int4");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Icon");

                    b.HasIndex("Sort");

                    b.HasIndex("Status");

                    b.HasIndex("Title");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("backend.Models.Entities.Slider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<int>("Sort")
                        .HasColumnType("int4");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Image");

                    b.HasIndex("Link");

                    b.HasIndex("Sort");

                    b.HasIndex("Status");

                    b.HasIndex("Title");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("backend.Models.Entities.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Facebook")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Instagram")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Sort")
                        .HasColumnType("int4");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<string>("Twitter")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Email");

                    b.HasIndex("Facebook");

                    b.HasIndex("Image");

                    b.HasIndex("Instagram");

                    b.HasIndex("LinkedIn");

                    b.HasIndex("Name");

                    b.HasIndex("Phone");

                    b.HasIndex("PositionName");

                    b.HasIndex("Sort");

                    b.HasIndex("Status");

                    b.HasIndex("Twitter");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("backend.Models.Entities.Testimonial", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Quote")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sort")
                        .HasColumnType("int4");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Image");

                    b.HasIndex("Name");

                    b.HasIndex("Position");

                    b.HasIndex("Sort");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("Testimonial");
                });

            modelBuilder.Entity("backend.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AboutMe")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ConfirmToken")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(191)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(191)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(191)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ResetToken")
                        .HasColumnType("varchar(191)");

                    b.Property<short>("Status")
                        .HasColumnType("int2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmToken");

                    b.HasIndex("Country");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Email");

                    b.HasIndex("FirstName");

                    b.HasIndex("Gender");

                    b.HasIndex("Image");

                    b.HasIndex("LastName");

                    b.HasIndex("Password");

                    b.HasIndex("Phone");

                    b.HasIndex("ResetToken");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedAt");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ArticleReference", b =>
                {
                    b.HasOne("backend.Models.Entities.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Entities.Reference", null)
                        .WithMany()
                        .HasForeignKey("ReferencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Entities.Article", b =>
                {
                    b.HasOne("backend.Models.Entities.User", "User")
                        .WithMany("Article")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Models.Entities.ArticleComment", b =>
                {
                    b.HasOne("backend.Models.Entities.Article", "Article")
                        .WithMany("ArticleComment")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Models.Entities.ArticleComment", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("backend.Models.Entities.User", "User")
                        .WithMany("ArticleComment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Models.Entities.Portfolio", b =>
                {
                    b.HasOne("backend.Models.Entities.Customer", "Customer")
                        .WithMany("Portfolio")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("backend.Models.Entities.Reference", "Reference")
                        .WithMany("Portfolio")
                        .HasForeignKey("ReferenceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("backend.Models.Entities.PortfolioImage", b =>
                {
                    b.HasOne("backend.Models.Entities.Portfolio", "Portfolio")
                        .WithMany("PortfolioImage")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("backend.Models.Entities.Testimonial", b =>
                {
                    b.HasOne("backend.Models.Entities.Customer", "Customer")
                        .WithMany("Testimonial")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("backend.Models.Entities.Article", b =>
                {
                    b.Navigation("ArticleComment");
                });

            modelBuilder.Entity("backend.Models.Entities.Customer", b =>
                {
                    b.Navigation("Portfolio");

                    b.Navigation("Testimonial");
                });

            modelBuilder.Entity("backend.Models.Entities.Portfolio", b =>
                {
                    b.Navigation("PortfolioImage");
                });

            modelBuilder.Entity("backend.Models.Entities.Reference", b =>
                {
                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("backend.Models.Entities.User", b =>
                {
                    b.Navigation("Article");

                    b.Navigation("ArticleComment");
                });
#pragma warning restore 612, 618
        }
    }
}
