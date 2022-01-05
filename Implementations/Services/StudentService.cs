using Microsoft.AspNetCore.Hosting;
using StudentMVCApp.Context;
using StudentMVCApp.DTOs;
using StudentMVCApp.Entities;
using StudentMVCApp.Interfaces.Repositories;
using StudentMVCApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            
        }
        public bool AddStudent(CreateStudentRequestModel model)
        {
           
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                DepartmentId = model.DepartmentId,
                StudentPhoto = model.StudentPhoto,
                Password = model.Password 
            };

            var courses = _courseRepository.GetSelectedCourses(model.Courses);
            foreach(var course in courses)
            {
                var studentCourse = new StudentCourse
                {
                    CourseId = course.Id,
                    Course = course,
                    Student = student,
                    StudentId = student.Id
                };
                student.StudentCourses.Add(studentCourse);
            }

            _studentRepository.Create(student);
            return true;
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(student);
        }

        public StudentDto GetStudent(int id)
        {
            var student = _studentRepository.Get(id);
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                StudentPhoto = student.StudentPhoto,
                Courses = student.StudentCourses.Select(c => new CourseDto
                {
                    Id = c.CourseId,
                    Name = c.Course.Name,
                   
                }).ToList()

            };
        }

        public IList<StudentDto> GetStudents()
        {
            return _studentRepository.GetAll().Select(d => new StudentDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DepartmentName = d.Department.Name,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber
            }).ToList();
        }

        public StudentDto Login(LoginRequestModel model)
        {
            var student = _studentRepository.GetByEmail(model.Email);
            if(student == null || student.Password != model.Password)
            {
                return null;
            }
            else
            {
                return new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    StudentPhoto = student.StudentPhoto,
                    Courses = student.StudentCourses.Select(c => new CourseDto
                    {
                        Id = c.CourseId,
                        Name = c.Course.Name,

                    }).ToList()

                };
            }
        }

        public bool UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            var student = _studentRepository.Get(id);
            student.Email = model.Email;
            student.PhoneNumber = model.PhoneNumber;
            _studentRepository.Update(student);
            return true;
        }
    }
}
