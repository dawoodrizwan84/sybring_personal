namespace sybring_personal.Models
{
    public class Project
    {
        public int Id { get; set; }
         public string? Name { get; set; }
        public string? Description { get; set; } = null;

       public virtual ICollection<User> ProjectUsers { get; set; }

        public virtual ICollection<TimeHistory> TimeId { get; set; }
    }
}
