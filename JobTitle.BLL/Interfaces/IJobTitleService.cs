using JobTitle.BLL.DTO;
using JobTitle.BLL.Enums;

namespace JobTitle.BLL.Interfaces
{
    public interface IJobTitleService
    {
        JobTitleDTO GetJobTitleById(int jobTitleId);
        JobTitlesDTO GetJobTitles();
        ResultStatus CreateJobTitle(string jobTitleName);
        ResultStatus UpdateJobTitle(int jobTitleId, string jobTitleName);
        ResultStatus DeleteJobTitle(int jobTitleId);

    }
}
