﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using article.data.context;

namespace article.api.Migrations
{
    [DbContext(typeof(articlecontext))]
    [Migration("20200830222459_initialize-v3")]
    partial class initializev3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("article.data.models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid?>("CategoryId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId1");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0727ed5-5785-4a3b-9b4e-6b0698720369"),
                            Content = "Article Content 1",
                            CreatedDate = new DateTime(2020, 8, 31, 1, 24, 59, 107, DateTimeKind.Local).AddTicks(4560),
                            FullName = "Full Name 1",
                            Title = "Article Title 1"
                        },
                        new
                        {
                            Id = new Guid("55da32c4-68b3-4a45-a4cc-ccdbeb6d3996"),
                            Content = "Article Content 2",
                            CreatedDate = new DateTime(2020, 8, 31, 1, 24, 59, 114, DateTimeKind.Local).AddTicks(3420),
                            FullName = "Full Name 2",
                            Title = "Article Title 2"
                        },
                        new
                        {
                            Id = new Guid("b7eed6ee-9cc2-445b-983c-277c8a540d2f"),
                            Content = "Article Content 3",
                            CreatedDate = new DateTime(2020, 8, 31, 1, 24, 59, 114, DateTimeKind.Local).AddTicks(3500),
                            FullName = "Full Name 3",
                            Title = "Article Title 3"
                        });
                });

            modelBuilder.Entity("article.data.models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("article.data.models.Article", b =>
                {
                    b.HasOne("article.data.models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId1");
                });
#pragma warning restore 612, 618
        }
    }
}
