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
        public ActionResult EditStudent(int id)
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());

            viewModel.Student = StudentRepository.Get(id);
            //viewModel.Student.Major = MajorRepository.Get(viewModel.Student.Major.MajorId);

            viewModel.Student.Courses = new List<Course>();

            foreach (var course in viewModel.SelectedCourseIds)
                viewModel.Student.Courses.Add(CourseRepository.Get(id));

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            //set view model properties 
            //get courses 
            //get major 
            //add student 
            //redirect to list view

            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);

                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

                StudentRepository.Edit(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                viewModel.SetStateItems(StateRepository.GetAll());

                viewModel.Student = StudentRepository.Get(studentVM.Student.StudentId);

                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var viewModel = new StudentVM();

            viewModel.Student = StudentRepository.Get(id);

            return View(viewModel.Student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);

            return RedirectToAction("List");
        }
    }
}