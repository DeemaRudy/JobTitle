using Microsoft.EntityFrameworkCore;
using JobTitleEntity = JobTitle.DAL.Entities.JobTitle;

namespace JobTitle.DAL.EF
{
    internal class JobTitleContext : DbContext
    {
        public string DbPath { get; }
        public JobTitleContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "JobTitles.db");
        }
        public DbSet<JobTitleEntity> JobTitles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
