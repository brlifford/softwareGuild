using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var student = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            viewModel.Student = student;
            viewModel.SetCourseItems(CourseRepository.GetAll());

            if(student.Courses != null)
            {
                viewModel.SelectedCourseIds = student.Courses.Select(c => c.CourseId).ToList();
            }
            
            

            viewModel.SetMajorItems(MajorRepository.GetAll());
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            var student = studentVM.Student;
            var allStudents = StudentRepository.GetAll();
            var selectedStudent = allStudents.FirstOrDefault(s => s.FirstName == student.FirstName);
            selectedStudent.GPA = student.GPA;
            selectedStudent.Address = student.Address;

            selectedStudent.Courses = new List<Course>();
            foreach (var id in studentVM.SelectedCourseIds)
            {
                
                selectedStudent.Courses.Add(CourseRepository.Get(id));
            }



            
            selectedStudent.Major = MajorRepository.Get(student.Major.MajorId);

            StudentRepository.Edit(selectedStudent);
            StudentRepository.SaveAddress(selectedStudent.StudentId, selectedStudent.Address);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}