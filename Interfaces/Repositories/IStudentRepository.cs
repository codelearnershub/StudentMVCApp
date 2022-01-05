using StudentMVCApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Student Create(Student student);
        Student Update(Student student);
        Student Get(int id);
        List<Student> GetAll();
        void Delete(Student student);
        Student GetByEmail(string email);
    }
}
