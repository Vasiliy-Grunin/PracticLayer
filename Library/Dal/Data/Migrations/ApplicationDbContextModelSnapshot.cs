﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Data.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookModelGenryModel", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookModelGenryModel");
                });

            modelBuilder.Entity("BookModelPeopleModel", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("MasterId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "MasterId");

                    b.HasIndex("MasterId");

                    b.ToTable("BookModelPeopleModel");
                });

            modelBuilder.Entity("DAL.Entitys.Model.AuthorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MidleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasDiscriminator<string>("Discriminator").IsComplete(false).HasValue("AuthorModel");
                });

            modelBuilder.Entity("DAL.Entitys.Model.BookModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasDiscriminator<string>("Discriminator").IsComplete(false).HasValue("BookModel");
                });

            modelBuilder.Entity("DAL.Entitys.Model.GenryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genries");

                    b.HasDiscriminator<string>("Discriminator").IsComplete(false).HasValue("GenryModel");
                });

            modelBuilder.Entity("DAL.Entitys.Model.PeopleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MidleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Peoples");

                    b.HasDiscriminator<string>("Discriminator").IsComplete(false).HasValue("PeopleModel");
                });

            modelBuilder.Entity("DAL.Entitys.Model.Inheritance.AuthorInheritance", b =>
                {
                    b.HasBaseType("DAL.Entitys.Model.AuthorModel");

                    b.Property<DateTime>("DateTimeAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeChange")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("AuthorInheritance");
                });

            modelBuilder.Entity("DAL.Entitys.Model.Inheritance.BookInheritance", b =>
                {
                    b.HasBaseType("DAL.Entitys.Model.BookModel");

                    b.Property<DateTime>("DateTimeAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeChange")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("BookInheritance");
                });

            modelBuilder.Entity("DAL.Entitys.Model.Inheritance.GenryInheritance", b =>
                {
                    b.HasBaseType("DAL.Entitys.Model.GenryModel");

                    b.Property<DateTime>("DateTimeAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeChange")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("GenryInheritance");
                });

            modelBuilder.Entity("DAL.Entitys.Model.Inheritance.PeopleInheritance", b =>
                {
                    b.HasBaseType("DAL.Entitys.Model.PeopleModel");

                    b.Property<DateTime>("DateTimeAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeChange")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PeopleInheritance");
                });

            modelBuilder.Entity("BookModelGenryModel", b =>
                {
                    b.HasOne("DAL.Entitys.Model.BookModel", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entitys.Model.GenryModel", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookModelPeopleModel", b =>
                {
                    b.HasOne("DAL.Entitys.Model.BookModel", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entitys.Model.PeopleModel", null)
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entitys.Model.BookModel", b =>
                {
                    b.HasOne("DAL.Entitys.Model.AuthorModel", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DAL.Entitys.Model.AuthorModel", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
