using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Construction;

namespace sybring_personal.Models.ViewModels
{
    public class ConsultantVM
    {
        public ConsultantVM()
        {
            UserProjects=new List<SelectListItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public List<SelectListItem> UserProjects { get; set; } = new List<SelectListItem>();

        public int ChosenProject {  get; set; }
        public User User { get; set; }

        public virtual Project Project { get; set; }
    }
}
