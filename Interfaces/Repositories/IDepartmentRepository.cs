using StudentMVCApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Department Create(Department department);
        Department Update(Department department);
        Department Get(int id);
        List<Department> GetAll();
        void Delete(Department department);
    }
}
