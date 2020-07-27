﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Model.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20200727121507_CurrentUserTable")]
    partial class CurrentUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.BlogThread", b =>
                {
                    b.Property<int>("BlogThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThreadName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogThreadId");

                    b.HasIndex("BlogUserId");

                    b.ToTable("BlogThreads");
                });

            modelBuilder.Entity("Database.BlogUser", b =>
                {
                    b.Property<int>("BlogUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passowrd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogUserId");

                    b.ToTable("BlogUsers");
                });

            modelBuilder.Entity("Database.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PostComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Database.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BlogThreadId")
                        .HasColumnType("int");

                    b.Property<int>("BlogUserId")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("PostContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("BlogThreadId");

                    b.HasIndex("BlogUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Database.BlogThread", b =>
                {
                    b.HasOne("Database.BlogUser", "BlogUser")
                        .WithMany("BlogThreads")
                        .HasForeignKey("BlogUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Comment", b =>
                {
                    b.HasOne("Database.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Post", b =>
                {
                    b.HasOne("Database.BlogThread", "BlogThread")
                        .WithMany("Posts")
                        .HasForeignKey("BlogThreadId");

                    b.HasOne("Database.BlogUser", "BlogUser")
                        .WithMany("Posts")
                        .HasForeignKey("BlogUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
