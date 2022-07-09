using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class ProgramType
    {
        public ProgramType()
        {
            Calenders = new HashSet<Calender>();
            Deparrtments = new HashSet<Deparrtment>();
            Enrollments = new HashSet<Enrollment>();
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
        }

        public int ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public string? ProgramCode { get; set; }

        public virtual ICollection<Calender> Calenders { get; set; }
        public virtual ICollection<Deparrtment> Deparrtments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
