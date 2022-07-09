using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Calender
    {
        public int CalenderId { get; set; }
        public string? CalenderName { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? ProgramId { get; set; }
        public int? EnrollmentId { get; set; }

        public virtual Enrollment? Enrollment { get; set; }
        public virtual ProgramType? Program { get; set; }
    }
}
