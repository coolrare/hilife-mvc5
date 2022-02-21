using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class CourseBatchUpdate
    {
        public int CourseID { get; set; }
        public int Credits { get; set; }
        public System.DateTime OpenDate { get; set; }
    }
}