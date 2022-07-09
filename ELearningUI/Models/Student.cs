using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Student
    {
        public Student()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Fname { get; set; }
        public string? Gfname { get; set; }
        public string? Uname { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? EnrollmentId { get; set; }
        public int? ProgramId { get; set; }
        public int? StatusId { get; set; }
        public int? DepartmentId { get; set; }
        public int? GradeId { get; set; }
        public int? AssessmentId { get; set; }

        public virtual Assessment? Assessment { get; set; }
        public virtual Deparrtment? Department { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
        public virtual Grade? Grade { get; set; }
        public virtual ProgramType? Status { get; set; }
        public virtual Status? StatusNavigation { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
