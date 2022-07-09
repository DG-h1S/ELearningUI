using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Status
    {
        public Status()
        {
            Admins = new HashSet<Admin>();
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
        }

        public int StatusId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string? Status1 { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? LastLoginIp { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
