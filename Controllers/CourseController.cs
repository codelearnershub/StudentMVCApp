using Microsoft.AspNetCore.Mvc;
using StudentMVCApp.DTOs;
using StudentMVCApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var courses = _courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseRequestModel model)
        {
            _courseService.AddCourse(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _courseService.GetCourse(id);
            return View(course);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var course = _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateCourseRequestModel model)
        {
            _courseService.UpdateCourse(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var course = _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
