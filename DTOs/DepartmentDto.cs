using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DepartmentCode { get; set; }

        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }

    public class CreateDepartmentRequestModel
    {
        public string Name { get; set; }

        public string DepartmentCode { get; set; }
    }

    public class UpdateDepartmentRequestModel
    {
        public string Name { get; set; }

        public string DepartmentCode { get; set; }
    }
}
