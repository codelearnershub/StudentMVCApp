using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMVCApp.DTOs;
using StudentMVCApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courseService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(IStudentService studentService, IDepartmentService departmentService, ICourseService courseService, IWebHostEnvironment webHostEnvironment)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _courseService = courseService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.GetDepartments();
            ViewData["Departments"] = new SelectList(departments, "Id", "Name");

            var courses = _courseService.GetCourses();
            ViewData["Courses"] = new SelectList(courses, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStudentRequestModel model, IFormFile studentPhoto)
        {
            string studentPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "studentPhotos");
            Directory.CreateDirectory(studentPhotoPath);
            string contentType = studentPhoto.ContentType.Split('/')[1];
            string studentImage = $"STD{Guid.NewGuid()}.{contentType}";
            string fullPath = Path.Combine(studentPhotoPath, studentImage);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                studentPhoto.CopyTo(fileStream);
            }
            model.StudentPhoto = studentImage;

            _studentService.AddStudent(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudent(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateStudentRequestModel model)
        {
            _studentService.UpdateStudent(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
