﻿namespace sybring_personal.Models
{
    public class TimeHistory
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public virtual ICollection<Project> ProjectId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
