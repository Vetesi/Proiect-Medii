﻿// <auto-generated />
using System;
using Cursuri.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cursuri.Migrations
{
    [DbContext(typeof(CursuriContext))]
    partial class CursuriContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cursuri.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Cursuri.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("ProfessorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.HasIndex("ProfessorID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Cursuri.Models.CourseGrade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("GradeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("GradeID");

                    b.ToTable("CourseGrade");
                });

            modelBuilder.Entity("Cursuri.Models.Enrolling", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrolmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("MemberID");

                    b.ToTable("Enrolling");
                });

            modelBuilder.Entity("Cursuri.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("GradeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("Cursuri.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Cursuri.Models.Professor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Cursuri.Models.Course", b =>
                {
                    b.HasOne("Cursuri.Models.City", "City")
                        .WithMany("Courses")
                        .HasForeignKey("CityID");

                    b.HasOne("Cursuri.Models.Professor", "Professor")
                        .WithMany("Courses")
                        .HasForeignKey("ProfessorID");

                    b.Navigation("City");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Cursuri.Models.CourseGrade", b =>
                {
                    b.HasOne("Cursuri.Models.Course", "Course")
                        .WithMany("CourseGrades")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cursuri.Models.Grade", "Grade")
                        .WithMany("CourseGrades")
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Cursuri.Models.Enrolling", b =>
                {
                    b.HasOne("Cursuri.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.HasOne("Cursuri.Models.Member", "Member")
                        .WithMany("Enrollments")
                        .HasForeignKey("MemberID");

                    b.Navigation("Course");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Cursuri.Models.City", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Cursuri.Models.Course", b =>
                {
                    b.Navigation("CourseGrades");
                });

            modelBuilder.Entity("Cursuri.Models.Grade", b =>
                {
                    b.Navigation("CourseGrades");
                });

            modelBuilder.Entity("Cursuri.Models.Member", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Cursuri.Models.Professor", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}