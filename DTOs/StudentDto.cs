using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public string StudentPhoto { get; set; }

        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }


    public class CreateStudentRequestModel
    {
        [Required]
        [StringLength(maximumLength:10, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Compare("FirstName", ErrorMessage ="LastName and FirstName must be the same")]
        [MaxLength(15)]
        [MinLength(5)]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        
        [DataType(DataType.EmailAddress, ErrorMessage ="")]

        public string Email { get; set; }

        [DisplayName("Student's Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        public string PhoneNumber { get; set; }
        
        public int DepartmentId { get; set; }

        public string StudentPhoto { get; set; }

        public IList<int> Courses { get; set; } = new List<int>();

    }

    public class UpdateStudentRequestModel
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
