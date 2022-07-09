using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Assessments = new HashSet<Assessment>();
        }

        public int QuizId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeClose { get; set; }
        public int? TimeLimit { get; set; }
        public int? Point { get; set; }
        public string? QuizCode { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
