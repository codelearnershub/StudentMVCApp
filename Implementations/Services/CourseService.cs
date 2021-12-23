using StudentMVCApp.DTOs;
using StudentMVCApp.Entities;
using StudentMVCApp.Interfaces.Repositories;
using StudentMVCApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Implementations.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public bool AddCourse(CreateCourseRequestModel model)
        {
            var course = new Course
            {
                Name = model.Name
            };
            _courseRepository.Create(course);
            return true;
        }

        public void DeleteCourse(int id)
        {
            var course = _courseRepository.Get(id);
            _courseRepository.Delete(course);
        }

        public CourseDto GetCourse(int id)
        {
            var course = _courseRepository.Get(id);
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                

            };
        }

        public IList<CourseDto> GetCourses()
        {
            return _courseRepository.GetAll().Select(n => new CourseDto
            {
                Id = n.Id,
                Name = n.Name,
                
            }).ToList();
        }

        public bool UpdateCourse(int id, UpdateCourseRequestModel model)
        {
            var course = _courseRepository.Get(id);
            course.Name = model.Name;
            
            _courseRepository.Update(course);
            return true;
        }
    }
}
