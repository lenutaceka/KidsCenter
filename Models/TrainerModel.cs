using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenter.Models
{
    public class TrainerModel
    {
        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }
    }
}