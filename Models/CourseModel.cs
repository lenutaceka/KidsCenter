using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public int TrainerId { get; set; }
        public int CourseCategoryId { get; set; }
        public int AgeCategoryId { get; set; }
        public int CoursePrice { get; set; }
        
    }
}