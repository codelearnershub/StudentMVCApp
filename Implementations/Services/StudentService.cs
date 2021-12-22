using StudentMVCApp.Context;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool AddStudent(CreateStudentRequestModel model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                DepartmentId = model.DepartmentId
            };
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
                DepartmentName = student.Department.Name,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber

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
