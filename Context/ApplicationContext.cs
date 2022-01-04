using Microsoft.EntityFrameworkCore;
using StudentMVCApp.Context.EfConfigurations;
using StudentMVCApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentMVCApp.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Pythons>().ToTable("Ship");
             modelBuilder.Entity<Pythons>().HasKey("Id");
             modelBuilder.Entity<Pythons>().HasIndex(a => a.Name).IsUnique();
             modelBuilder.Entity<Pythons>().Property(a => a.Name).IsRequired().HasMaxLength(10).HasColumnType("varchar").HasColumnName("PythonName");
             modelBuilder.Entity<Student>()
                 .HasMany(d => d.StudentCourses)
                 .WithOne(d => d.Student)
                 .HasForeignKey(d => d.StudentId)
                 .OnDelete(DeleteBehavior.Restrict);*/
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Pythons> Pythons { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}

