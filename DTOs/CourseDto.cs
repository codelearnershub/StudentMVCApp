using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }

    public class CreateCourseRequestModel
    {
        public string Name { get; set; }
    }

    public class UpdateCourseRequestModel
    {
        public string Name { get; set; }
    }
}
