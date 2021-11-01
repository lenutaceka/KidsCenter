using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.Models
{
    public class CourseMembershipModel
    {
        public int MembershipId { get; set; }
        public int CourseId { get; set; }
        public int ChildId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}