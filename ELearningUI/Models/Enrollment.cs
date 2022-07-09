using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            Calenders = new HashSet<Calender>();
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
        }

        public int EnrollmentId { get; set; }
        public int? CourseId { get; set; }
        public int? ProgramId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Deparrtment? Department { get; set; }
        public virtual ProgramType? Program { get; set; }
        public virtual ICollection<Calender> Calenders { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
