using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }


    public class CreateStudentRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public IList<int> Courses { get; set; } = new List<int>();

    }

    public class UpdateStudentRequestModel
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
