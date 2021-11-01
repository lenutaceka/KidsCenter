using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.Models
{
    public class ChildrenModel
    {
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}