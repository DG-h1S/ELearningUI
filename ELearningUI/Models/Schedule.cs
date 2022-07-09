using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public string? CourseStartDateTime { get; set; }
        public int? AdminId { get; set; }
        public int? LectureId { get; set; }
        public int? StudentId { get; set; }
        public int? AssessmentId { get; set; }

        public virtual Admin? Admin { get; set; }
        public virtual Assessment? Assessment { get; set; }
        public virtual Lecturer? Lecture { get; set; }
        public virtual Student? Student { get; set; }
    }
}
