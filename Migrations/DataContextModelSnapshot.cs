﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTrackerBackend.Services.Context;

#nullable disable

namespace TaskTrackerBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskTrackerBackend.Models.AppModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AppInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.BoardModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BoardID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BoardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserModelID");

                    b.ToTable("BoardInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.CommentsModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<int?>("PostModelID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PostModelID");

                    b.ToTable("CommentInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.DTO.CommentReplyDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CommentID")
                        .HasColumnType("int");

                    b.Property<int?>("CommentReplyDTOID")
                        .HasColumnType("int");

                    b.Property<int?>("CommentsModelID")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CommentReplyDTOID");

                    b.HasIndex("CommentsModelID");

                    b.ToTable("CommentReplyDTO");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.PostModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<string>("BoardID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BoardModelID")
                        .HasColumnType("int");

                    b.Property<string>("DateCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PriorityLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BoardModelID");

                    b.ToTable("PostInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.UserModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool?>("AccountCreated")
                        .HasColumnType("bit");

                    b.Property<string>("BoardIDs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("joinDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.BoardModel", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.UserModel", null)
                        .WithMany("BoardInfo")
                        .HasForeignKey("UserModelID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.CommentsModel", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.PostModel", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostModelID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.DTO.CommentReplyDTO", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.DTO.CommentReplyDTO", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentReplyDTOID");

                    b.HasOne("TaskTrackerBackend.Models.CommentsModel", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentsModelID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.PostModel", b =>
                {
                    b.HasOne("TaskTrackerBackend.Models.BoardModel", null)
                        .WithMany("Posts")
                        .HasForeignKey("BoardModelID");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.BoardModel", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.CommentsModel", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.DTO.CommentReplyDTO", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.PostModel", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TaskTrackerBackend.Models.UserModel", b =>
                {
                    b.Navigation("BoardInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
