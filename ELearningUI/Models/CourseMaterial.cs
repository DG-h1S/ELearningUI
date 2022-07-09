using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class CourseMaterial
    {
        public int CourseMaterialId { get; set; }
        public string? MaterialName { get; set; }
        public string? Description { get; set; }
        public string? File { get; set; }
        public int? LectureId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Lecturer? Lecture { get; set; }
    }
}
