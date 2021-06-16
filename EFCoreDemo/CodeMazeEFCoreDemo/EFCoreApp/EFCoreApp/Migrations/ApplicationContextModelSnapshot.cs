﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EvaluationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalExplanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Evaluation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b7e053a-70c1-411b-a9a8-b3fea29ce497"),
                            AdditionalExplanation = "First test...",
                            Grade = 5,
                            StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a")
                        },
                        new
                        {
                            Id = new Guid("324a960a-f0c2-497f-888f-f4dbcb5e3947"),
                            AdditionalExplanation = "Second test...",
                            Grade = 4,
                            StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a")
                        },
                        new
                        {
                            Id = new Guid("280b4e48-56b3-42d4-8b3e-7519d754e9b9"),
                            AdditionalExplanation = "First test...",
                            Grade = 3,
                            StudentId = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac")
                        },
                        new
                        {
                            Id = new Guid("ea32101a-3307-4ebc-9f27-afab8245b52d"),
                            AdditionalExplanation = "Last test...",
                            Grade = 2,
                            StudentId = new Guid("4addc421-0937-45cb-b55c-200b45c6caca")
                        });
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRegularStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_Student_Name");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                            Age = 30,
                            Deleted = false,
                            IsRegularStudent = false,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"),
                            Age = 25,
                            Deleted = false,
                            IsRegularStudent = false,
                            Name = "Jane Doe"
                        },
                        new
                        {
                            Id = new Guid("4addc421-0937-45cb-b55c-200b45c6caca"),
                            Age = 28,
                            Deleted = false,
                            IsRegularStudent = false,
                            Name = "Mike Miles"
                        });
                });

            modelBuilder.Entity("Entities.StudentDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("Entities.StudentSubject", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                            SubjectId = new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8")
                        },
                        new
                        {
                            StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                            SubjectId = new Guid("89fc9e5d-74f6-4d2e-ae82-76f2b1decce7")
                        },
                        new
                        {
                            StudentId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                            SubjectId = new Guid("9e5f12c2-0aa2-49b0-9db2-7df40fecf9ad")
                        },
                        new
                        {
                            StudentId = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"),
                            SubjectId = new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f")
                        },
                        new
                        {
                            StudentId = new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"),
                            SubjectId = new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8")
                        },
                        new
                        {
                            StudentId = new Guid("4addc421-0937-45cb-b55c-200b45c6caca"),
                            SubjectId = new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f")
                        });
                });

            modelBuilder.Entity("Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subject");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8"),
                            SubjectName = "Math"
                        },
                        new
                        {
                            Id = new Guid("89fc9e5d-74f6-4d2e-ae82-76f2b1decce7"),
                            SubjectName = "English"
                        },
                        new
                        {
                            Id = new Guid("9e5f12c2-0aa2-49b0-9db2-7df40fecf9ad"),
                            SubjectName = "History"
                        },
                        new
                        {
                            Id = new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f"),
                            SubjectName = "Computer Science"
                        });
                });

            modelBuilder.Entity("Entities.Evaluation", b =>
                {
                    b.HasOne("Entities.Student", "Student")
                        .WithMany("Evaluations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.StudentDetails", b =>
                {
                    b.HasOne("Entities.Student", "Student")
                        .WithOne("StudentDetails")
                        .HasForeignKey("Entities.StudentDetails", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.StudentSubject", b =>
                {
                    b.HasOne("Entities.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
