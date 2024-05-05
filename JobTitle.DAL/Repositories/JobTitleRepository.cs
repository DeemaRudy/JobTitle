using JobTitle.DAL.EF;
using JobTitle.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using JobTitleEntity = JobTitle.DAL.Entities.JobTitle;
namespace JobTitle.DAL.Repositories
{
    internal class JobTitleRepository : IRepository<JobTitleEntity>
    {
        private readonly JobTitleContext _context;
        public JobTitleRepository(JobTitleContext context)
        {
            _context = context;
        }
        public JobTitleEntity GetById(int jobTitleId)
        {
            return _context.JobTitles.FirstOrDefault(item => item.Id == jobTitleId);
        }
        public JobTitleEntity GetByName(string jobTitleName)
        {
            return _context.JobTitles.FirstOrDefault(item => item.Name == jobTitleName);
        }
        public IEnumerable<JobTitleEntity> GetAll()
        {
            return _context.JobTitles;
        }
        public bool Create(JobTitleEntity jobTitle)
        {
            var entity = _context.JobTitles.FirstOrDefault(item => item.Id == jobTitle.Id);
            if (entity == null)
            {
                _context.Add(jobTitle);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Update(JobTitleEntity item)
        {
            var entity = GetById(item.Id);
            if (entity == null)
            {
                return false;
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
