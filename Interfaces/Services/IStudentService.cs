using StudentMVCApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Interfaces.Services
{
    public interface IStudentService
    {
        bool AddStudent(CreateStudentRequestModel model);
        bool UpdateStudent(int id, UpdateStudentRequestModel model);
        StudentDto GetStudent(int id);

        IList<StudentDto> GetStudents();

        void DeleteStudent(int id);
    }
}
