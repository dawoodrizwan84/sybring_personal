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
                Email = consultantVM.Email,
                Project = _db.Projects.FirstOrDefault(f => f.Id == consultantVM.ChosenProject)!,


            };

            _db.Consultants.Add(dbCons);
            _db.SaveChanges();

        }

        public async Task<bool> DeleteConsultantAsync(int id)
        {
            try
            {
                var del = await GetConsultantByIdAsync(id);
               
                if (del == null) 
                {
                    return false;
                }
                _db.Consultants.Remove(del);
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
           var byId = await _db.Consultants.FindAsync(id);

            return byId;
        }

        public async Task<List<Consultant>> GetConsultantsAsync()
        {
            var list = await _db.Consultants.Include(a => a.Project)
                .OrderByDescending(a =>a.User).ToListAsync();
            return list;
        }

        public Task<List<Project>> GetProjects()
        {
           return _db.Projects.ToListAsync();
        }

        public async Task<bool> UpdateConsultantAsync(ConsultantVM consultantVM)
        {
            try
            {
                var existingConsultant = await _db.Consultants.FindAsync(consultantVM.Id);

                if (existingConsultant == null)
                {
                    return false;
                }

              
                existingConsultant.Name = consultantVM.Name;
                existingConsultant.Address = consultantVM.Address;
                existingConsultant.Price = consultantVM.Price;
                existingConsultant.Description = consultantVM.Description;
                existingConsultant.ProjectId = consultantVM.ProjectId;
                existingConsultant.Email = consultantVM.Email;
                existingConsultant.Project = _db.Projects.FirstOrDefault(f => f.Id == consultantVM.ChosenProject);

                _db.Update(existingConsultant);
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


