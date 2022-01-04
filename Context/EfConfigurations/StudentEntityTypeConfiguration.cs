using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentMVCApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Context.EfConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.Property(s => s.Id)
                .HasColumnType("int").IsRequired();
            builder.HasIndex(s => s.Email).IsUnique();
            builder.HasMany(s => s.StudentCourses)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
