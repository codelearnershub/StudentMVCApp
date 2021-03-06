using Microsoft.EntityFrameworkCore;
using StudentMVCApp.Context;
using StudentMVCApp.DTOs;
using StudentMVCApp.Entities;
using StudentMVCApp.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;
        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Student Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public Student Get(int id)
        {
            return _context.Students.Include(s => s.StudentCourses).ThenInclude(st => st.Course).SingleOrDefault(s => s.Id == id);
        }

        public Student GetByEmail(string email)
        {
            return _context.Students.Include(s => s.StudentCourses).ThenInclude(st => st.Course).SingleOrDefault(s => s.Email == email);
        }

        public List<Student> GetAll()
        {
            return _context.Students.Include(s => s.Department)
                .Include(s => s.StudentCourses)
                .ThenInclude(st => st.Course)
                .ToList();
        }

        public Student Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}
