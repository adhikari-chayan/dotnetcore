using Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Old Config

            //modelBuilder.Entity<Student>()
            //  .ToTable("Student");

            ////modelBuilder.Entity<Student>()
            ////    .HasKey(s => new { s.Id, s.AnotherKeyProperty });

            ////modelBuilder.Entity<Student>()
            ////    .Property(s => s.Name)
            ////    .IsRequired()
            ////    .HasMaxLength(50);

            //modelBuilder.Entity<Student>()
            //    .HasIndex(s => s.Name)
            //    .HasName("IX_Student_Name");

            //modelBuilder.Entity<Student>()
            //    .Property(s => s.Age)
            //    .IsRequired(false);

            //modelBuilder.Entity<Student>()
            //    .Ignore(s => s.LocalCalculation);

            //modelBuilder.Entity<Student>()
            //     .Property(s => s.IsRegularStudent)
            //     .HasDefaultValue(true);

            ////modelBuilder.Entity<Student>()
            ////    .HasIndex(s => s.IndexableUniqueProperty)
            ////    .HasName("index_test")
            ////    .IsUnique();



            //modelBuilder.Entity<Student>()
            //    .HasData(
            //          new Student
            //          {
            //              Id = Guid.NewGuid(),
            //              Name = "John Doe",
            //              Age = 30
            //          },
            //          new Student
            //          {
            //              Id = Guid.NewGuid(),
            //              Name = "Jane Doe",
            //              Age = 25
            //          }
            //    );

            #endregion

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationConfiguration());

        }
    }
}
