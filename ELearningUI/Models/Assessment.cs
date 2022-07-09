using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Assessment
    {
        public Assessment()
        {
            Grades = new HashSet<Grade>();
            Schedules = new HashSet<Schedule>();
            Students = new HashSet<Student>();
        }

        public int AssessmentId { get; set; }
        public string? AssessmentCode { get; set; }
        public string? Attendance { get; set; }
        public int? AssignmentId { get; set; }
        public int? QuizId { get; set; }
        public int? ExamId { get; set; }
        public int? LecturerId { get; set; }

        public virtual Assignment? Assignment { get; set; }
        public virtual Exam? Exam { get; set; }
        public virtual Lecturer? Lecturer { get; set; }
        public virtual Quiz? Quiz { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
