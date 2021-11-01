using KidsCenter.Models;
using KidsCenter.Models.DbObjects;
using KidsCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.Repository
{
    public class CourseRepository
    {
        private KidsCenterModelsDataContext dbContext;

        public CourseRepository()
        {
            dbContext = new KidsCenterModelsDataContext();
        }

        public CourseRepository(KidsCenterModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //original get all courses function, without viewmodel
        public List<CourseModel> GetAllCourses()
        {
            List<CourseModel> courseList = new List<CourseModel>();
            foreach (Course dbCourse in dbContext.Courses)
            {
                courseList.Add(MapDbObjectToModel(dbCourse));
            }
            return courseList;
        }

        public List<CourseViewModel> GetAllCoursesVM()
        {
            List<CourseViewModel> courseViewModels = new List<CourseViewModel>();
            List<CourseModel> courseList = GetAllCourses();

            for (var i = 0; i < courseList.Count; i++)
            {
                courseViewModels.Add(new CourseViewModel());
                courseViewModels[i].CourseId = courseList[i].CourseId;
                courseViewModels[i].FirstName = dbContext.Trainers.FirstOrDefault(x => x.TrainerId == courseList[i].TrainerId).FirstName;
                courseViewModels[i].LastName = dbContext.Trainers.FirstOrDefault(x => x.TrainerId == courseList[i].TrainerId).LastName;
                courseViewModels[i].CourseCategoryName = dbContext.CourseCategories.FirstOrDefault(x => x.CourseCategoryId == courseList[i].CourseCategoryId).CourseCategoryName;
                courseViewModels[i].AgeCategoryName = dbContext.AgeCategories.FirstOrDefault(x => x.AgeCategoryId == courseList[i].AgeCategoryId).AgeCategoryName;
                courseViewModels[i].CoursePrice = courseList[i].CoursePrice;
            }
            return courseViewModels;
        }


        public CourseModel GetCourseById(int id)
        {
            return MapDbObjectToModel(dbContext.Courses.FirstOrDefault(x => x.CourseId == id));
        }

        public void InsertCourse(CourseModel courseModel)
        {
            dbContext.Courses.InsertOnSubmit(MapModelToDbObject(courseModel));
            dbContext.SubmitChanges();
        }


        public void UpdateCourse(CourseModel courseModel)
        {
            Course course = dbContext.Courses.FirstOrDefault(x => x.CourseId == courseModel.CourseId);
            if (course != null)
            {
                course.CourseId = courseModel.CourseId;
                course.TrainerId = courseModel.TrainerId;
                course.CourseCategoryId = courseModel.CourseCategoryId;
                course.AgeCategoryId = courseModel.AgeCategoryId;
                course.CoursePrice = courseModel.CoursePrice;
                dbContext.SubmitChanges();
            }
        }

      
        public void DeleteCourse(int id)
        {
            Course course = dbContext.Courses.FirstOrDefault(x => x.CourseId == id);
            if (course != null)
            {
                dbContext.Courses.DeleteOnSubmit(course);
                dbContext.SubmitChanges();
            }
        }

        private Course MapModelToDbObject(CourseModel courseModel)
        {
            Course dbCourse = new Course();
            if (courseModel != null)
            {
                dbCourse.CourseId = courseModel.CourseId;
                dbCourse.TrainerId = courseModel.TrainerId;
                dbCourse.CourseCategoryId = courseModel.CourseCategoryId;
                dbCourse.AgeCategoryId = courseModel.AgeCategoryId;
                dbCourse.CoursePrice = courseModel.CoursePrice;

                return dbCourse;
            }
            return null;
        }


        private CourseModel MapDbObjectToModel(Course dbCourse)
        {
            CourseModel courseModel = new CourseModel();
            if (dbCourse != null)
            {
                courseModel.CourseId = dbCourse.CourseId;
                courseModel.TrainerId = dbCourse.TrainerId;
                courseModel.CourseCategoryId = dbCourse.CourseCategoryId;
                courseModel.AgeCategoryId = dbCourse.AgeCategoryId;
                courseModel.CoursePrice = dbCourse.CoursePrice;

                return courseModel;
            }
            return null;
        }
    }
}