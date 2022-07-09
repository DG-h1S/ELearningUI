using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Assessments = new HashSet<Assessment>();
        }

        public int AssignmentId { get; set; }
        public DateTime? TimeLimit { get; set; }
        public string? SubmitDate { get; set; }
        public string? Point { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
