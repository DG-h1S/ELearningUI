using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseMaterials = new HashSet<CourseMaterial>();
            Enrollments = new HashSet<Enrollment>();
            Grades = new HashSet<Grade>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public int? CourseCreditHour { get; set; }

        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
