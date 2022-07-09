using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Deparrtment
    {
        public Deparrtment()
        {
            Enrollments = new HashSet<Enrollment>();
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? TotalCourse { get; set; }
        public int? TotalCreditHr { get; set; }
        public int? ProgramId { get; set; }

        public virtual ProgramType? Program { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
