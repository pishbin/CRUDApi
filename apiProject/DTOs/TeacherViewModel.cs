using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiProject.DTOs
{
    public class TeacherViewModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string family { get; set; }

        //public  ICollection<CourseViewModel> Courses { get; set; }
    }
}