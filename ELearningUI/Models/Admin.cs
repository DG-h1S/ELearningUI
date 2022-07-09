using System;
using System.Collections.Generic;

namespace ELearningUI.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int AdminId { get; set; }
        public string? Name { get; set; }
        public string? Fname { get; set; }
        public string? Gname { get; set; }
        public string? Uname { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
