using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiProject.DTOs
{
    public class ResultApi
    {
        public int Errorcode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public object ModelDto { get; set; }
    }
}