using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiProject.DTOs
{
    public class CourseViewModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public int unit { get; set; }

        public Nullable<int> teacherId { get; set; }

        public ICollection<UnitSelectViewModel> UnitSelects { get; set; }

    }
}