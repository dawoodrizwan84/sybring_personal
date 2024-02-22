namespace sybring_personal.Models
{
    public class Billing
    {
        public int Id { get; set; }

        public string BilDescription { get; set; } = string.Empty;

        public double Cost { get; set; }

        public virtual ICollection<Project> ProjectId { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
