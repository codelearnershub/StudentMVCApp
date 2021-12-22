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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public bool AddDepartment(CreateDepartmentRequestModel model)
        {
            var department = new Department
            {
                Name = model.Name,
                DepartmentCode = model.DepartmentCode
            };
            _departmentRepository.Create(department);
            return true;
        }

        public void DeleteDepartment(int id)
        {
            var department = _departmentRepository.Get(id);
            _departmentRepository.Delete(department);
        }

        public DepartmentDto GetDepartment(int id)
        {
            var department = _departmentRepository.Get(id);
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                DepartmentCode = department.DepartmentCode

            };
        }

        public IList<DepartmentDto> GetDepartments()
        {
            return _departmentRepository.GetAll().Select(n => new DepartmentDto
            {
                Id = n.Id,
                Name = n.Name,
                DepartmentCode = n.DepartmentCode
            }).ToList();
        }

        public bool UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            var department = _departmentRepository.Get(id);
            department.Name = model.Name;
            department.DepartmentCode = model.DepartmentCode;
            _departmentRepository.Update(department);
            return true;
        }
    }
}
