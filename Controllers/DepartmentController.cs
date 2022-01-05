using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentMVCApp.DTOs;
using StudentMVCApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        public IActionResult Index()
        {
            var departments = _departmentService.GetDepartments();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentRequestModel model)
        {
            _departmentService.AddDepartment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentService.GetDepartment(id);
            return View(department);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateDepartmentRequestModel model)
        {
            _departmentService.UpdateDepartment(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}
