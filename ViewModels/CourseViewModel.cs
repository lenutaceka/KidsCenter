using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseCategoryName { get; set; }
        public string AgeCategoryName { get; set; }

        public int CoursePrice { get; set; }
    }
}