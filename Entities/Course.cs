using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Entities
{
    public class Course
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }= new List<StudentCourse>(); 
    }
}
