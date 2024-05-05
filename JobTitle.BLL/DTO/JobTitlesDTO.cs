using JobTitle.BLL.Enums;

namespace JobTitle.BLL.DTO
{
    public class JobTitlesDTO
    {
        public JobTitlesDTO()
        {
            jobTitles = new List<JobTitleBase>();
        }
        public IList<JobTitleBase> jobTitles { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }
}
