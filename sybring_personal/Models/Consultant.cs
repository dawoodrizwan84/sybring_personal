namespace sybring_personal.Models
{
    public class Consultant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public User User { get; set; }

        public virtual Project Project { get; set; }


    }
}
