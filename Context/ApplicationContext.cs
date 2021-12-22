using Microsoft.EntityFrameworkCore;
using StudentMVCApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }


    }
}

