using KidsCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.ViewModels
{
    public class EditCourseViewModel
    {
        public CourseModel Course { get; set; }
        public string FirstName { get; set; }

        public string AgeCategoryName { get; set; }
        public string CourseCategoryName { get; set; }

        public int CoursePrice { get; set; }
    }
}