using KidsCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.ViewModels
{
    public class CreateCourseViewModel
    {
        public CourseModel Course { get; set; }
        public List<TrainerModel> FirstNameList { get; set; }

        public List<AgeCategoryModel> AgeCategories { get; set; }
        public List<CourseCategoryModel> CourseCategories { get; set; }

        public int CoursePrice { get; set; }

        public CreateCourseViewModel()
        {
            this.Course = new CourseModel();
        }
    }
}