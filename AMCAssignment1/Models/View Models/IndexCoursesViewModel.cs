using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMCAssignment1.Models.View_Models
{
    public class IndexCoursesViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int NumberOfHours { get; set; }
        public int NumberOfEnrollments { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
    }
}