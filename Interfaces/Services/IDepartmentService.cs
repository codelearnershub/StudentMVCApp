using StudentMVCApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Interfaces.Services
{
    public interface IDepartmentService
    {
        bool AddDepartment(CreateDepartmentRequestModel model);
        bool UpdateDepartment(int id, UpdateDepartmentRequestModel model);
        DepartmentDto GetDepartment(int id);

        IList<DepartmentDto> GetDepartments();

        void DeleteDepartment(int id);
    }
}
