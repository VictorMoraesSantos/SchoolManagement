﻿// <auto-generated />
using System;
using Academic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Academic.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250412060807_AddUniqueIndexToCourseCode")]
    partial class AddUniqueIndexToCourseCode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Academic.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Credits")
                        .HasColumnType("integer");

                    b.Property<int?>("DepartamentId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DepartamentId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Academic.Domain.Entities.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("Academic.Domain.Entities.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Core.Domain.Events.DomainEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int?>("DepartamentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("ProgramId");

                    b.ToTable("DomainEvent");
                });

            modelBuilder.Entity("Academic.Domain.Entities.Course", b =>
                {
                    b.HasOne("Academic.Domain.Entities.Departament", null)
                        .WithMany("Courses")
                        .HasForeignKey("DepartamentId");

                    b.HasOne("Academic.Domain.Entities.Program", null)
                        .WithMany("Courses")
                        .HasForeignKey("ProgramId");
                });

            modelBuilder.Entity("Core.Domain.Events.DomainEvent", b =>
                {
                    b.HasOne("Academic.Domain.Entities.Course", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("CourseId");

                    b.HasOne("Academic.Domain.Entities.Departament", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("DepartamentId");

                    b.HasOne("Academic.Domain.Entities.Program", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("ProgramId");
                });

            modelBuilder.Entity("Academic.Domain.Entities.Course", b =>
                {
                    b.Navigation("DomainEvents");
                });

            modelBuilder.Entity("Academic.Domain.Entities.Departament", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("DomainEvents");
                });

            modelBuilder.Entity("Academic.Domain.Entities.Program", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("DomainEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
