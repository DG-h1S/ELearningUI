using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public string? GradeInLetter { get; set; }
        public int? CourseId { get; set; }
        public int? AssessmentId { get; set; }

        public virtual Assessment? Assessment { get; set; }
        public virtual Course? Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
