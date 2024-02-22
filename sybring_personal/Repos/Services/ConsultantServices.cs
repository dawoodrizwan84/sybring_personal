using Microsoft.EntityFrameworkCore;
using sybring_personal.Data;
using sybring_personal.Models;
using sybring_personal.Models.ViewModels;
using sybring_personal.Repos.Interface;

namespace sybring_personal.Repos.Services
{
    public class ConsultantServices : IConsultantServicves
    {
        private readonly ApplicationDbContext _db;
        

        public ConsultantServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddConsultant(ConsultantVM consultantVM, string userId)
        {
            Consultant dbCons = new Consultant() 
            {
                Name = consultantVM.Name,
                Address = consultantVM.Address,
                Price = consultantVM.Price,
                Description = consultantVM.Description,
                ProjectId = consultantVM.ProjectId,
                Project = _db.projects.FirstOrDefault(f => f.Id == consultantVM.ChosenProject)!,


            };

            _db.consultants.Add(dbCons);
            _db.SaveChanges();

        }

        public async Task<bool> DeleteConsultantAsync(int id)
        {
            try
            {
                var del = await GetConsultantByIdAsync(id);
               
                if (del != null) 
                {
                    return false;
                }
                _db.consultants.Remove(del);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Consultant> GetConsultantByIdAsync(int id)
        {
           var byId = await _db.consultants.FindAsync(id);

            return byId;
        }

        public async Task<List<Consultant>> GetConsultantsAsync()
        {
            var list = await _db.consultants.Include(a => a.Project)
                .OrderByDescending(a =>a.User).ToListAsync();
            return list;
        }

        public Task<List<Project>> GetProjects()
        {
           return _db.projects.ToListAsync();
        }

        public async Task<bool> UpdateConsultantAsync(ConsultantVM consultantVM)
        {
            Consultant dbCons = new Consultant()
            {
                Name = consultantVM.Name,
                Address = consultantVM.Address,
                Price = consultantVM.Price,
                Description = consultantVM.Description,
                ProjectId = consultantVM.ProjectId,
                Project = _db.projects.FirstOrDefault(f => f.Id == consultantVM.ChosenProject)!,


            };
            try
            {
                _db.Update(dbCons);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
