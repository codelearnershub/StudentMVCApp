using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Entities
{
   
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        public int DepartmentId { get; set; }


        public Department Department { get; set; }

        public string StudentPhoto { get; set; }

        public string Password { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
