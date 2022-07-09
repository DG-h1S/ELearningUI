using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Assessments = new HashSet<Assessment>();
        }

        public int ExamId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeClose { get; set; }
        public int? TimeLimit { get; set; }
        public string? ExamCode { get; set; }
        public int Point { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
