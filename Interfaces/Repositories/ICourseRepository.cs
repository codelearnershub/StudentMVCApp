using StudentMVCApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Course Create(Course course);
        Course Update(Course course);
        Course Get(int id);
        List<Course> GetAll();
        void Delete(Course course);
        IEnumerable<Course> GetSelectedCourses(IList<int> ids);
    }
}
