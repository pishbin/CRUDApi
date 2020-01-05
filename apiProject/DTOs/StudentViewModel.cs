using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiProject.DTOs
{
    public class StudentViewModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string family { get; set; }

        public string address { get; set; }

        public ICollection<UnitSelectViewModel> UnitSelects { get; set; }
    }
}