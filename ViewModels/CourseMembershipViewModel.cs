using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.ViewModels
{
    public class CourseMembershipViewModel
    {
        public int MembershipID { get; set; }

        public int CourseCategoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}