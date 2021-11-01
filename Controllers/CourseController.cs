using KidsCenter.Models;
using KidsCenter.Models.DbObjects;
using KidsCenter.Repository;
using KidsCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenter.Controllers
{
    public class CourseController : Controller
    {
        CourseRepository courseRepository = new CourseRepository();
        AgeCategoryRepository ageCategoryRepository = new AgeCategoryRepository();
        CourseCategoryRepository courseCategoryRepository = new CourseCategoryRepository();
        TrainerRepository trainerRepository = new TrainerRepository();

        // GET: Course
        public ActionResult Index()
        {
            //List<CourseModel> Courses = courseRepository.GetAllCourses(); -- original statement
            List<CourseViewModel> coursesAvailable = courseRepository.GetAllCoursesVM();
            return View("Index", coursesAvailable);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            CourseModel courseModel = courseRepository.GetCourseById(id);

            //var courseMembershipVM = new CourseMembershipViewModel();
            //courseMembershipVM = Course.courseModel;

            return View("Details", courseModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var course = new Course();
            CreateCourseViewModel createViewModel = new CreateCourseViewModel();
            createViewModel.FirstNameList = trainerRepository.GetAllTrainers();
            createViewModel.AgeCategories = ageCategoryRepository.GetAllCategories();
            createViewModel.CourseCategories = courseCategoryRepository.GetAllCourseCategories();
            createViewModel.CoursePrice = course.CoursePrice;

            return View(createViewModel);
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CreateCourseViewModel model = new CreateCourseViewModel();
                model.FirstNameList = trainerRepository.GetAllTrainers();
                model.AgeCategories = ageCategoryRepository.GetAllCategories();
                model.CourseCategories = courseCategoryRepository.GetAllCourseCategories();

                UpdateModel(model);
                courseRepository.InsertCourse(model.Course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            CourseModel courseModel = courseRepository.GetCourseById(id);
            return View("EditCourse", courseModel);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CourseModel courseModel = new CourseModel();
                UpdateModel(courseModel);
                courseRepository.UpdateCourse(courseModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCourse");
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            CourseModel courseModel = courseRepository.GetCourseById(id);
            return View("DeleteCourse", courseModel);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                courseRepository.DeleteCourse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCourse");
            }
        }
    }
}
