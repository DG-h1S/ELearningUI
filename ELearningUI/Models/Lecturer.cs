using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Assessments = new HashSet<Assessment>();
            CourseMaterials = new HashSet<CourseMaterial>();
            Schedules = new HashSet<Schedule>();
        }

        public int LecturerId { get; set; }
        public string? Name { get; set; }
        public string? Fname { get; set; }
        public string? Gfname { get; set; }
        public string? Uname { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? ProgramId { get; set; }
        public int? DepartmentId { get; set; }
        public int? EnrollmentId { get; set; }
        public int? StatusId { get; set; }

        public virtual Deparrtment? Department { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
        public virtual ProgramType? Program { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
