using StudentMVCApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Interfaces.Services
{
    public interface ICourseService
    {
        bool AddCourse(CreateCourseRequestModel model);
        bool UpdateCourse(int id, UpdateCourseRequestModel model);
        CourseDto GetCourse(int id);

        IList<CourseDto> GetCourses();

        void DeleteCourse(int id);
    }
}
