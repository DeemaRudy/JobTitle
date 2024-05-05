using JobTitle.BLL.DTO;
using JobTitle.BLL.Enums;
using JobTitle.BLL.Interfaces;
using JobTitle.DAL.Interfaces;
using JobTitleEntity = JobTitle.DAL.Entities.JobTitle;

namespace JobTitle.BLL.Services
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IRepository<JobTitleEntity> _repository;
        public JobTitleService(IRepository<JobTitleEntity> repository)
        {
            _repository = repository;
        }
        public JobTitleDTO GetJobTitleById(int jobTitleId)
        {
            var entity = _repository.GetById(jobTitleId);
            if (entity == null)
            {
                return MapJobTitleToDTO(entity, ResultStatus.NotExisted);
            }

            return MapJobTitleToDTO(entity);

        }
        public JobTitlesDTO GetJobTitles()
        {
            var entities = _repository.GetAll();
            var result = new JobTitlesDTO();
            if (entities == null || !entities.Any()) 
            {
                result.ResultStatus = ResultStatus.Ok;
                return result;
            }

            foreach (var item in entities)
            {
                result.jobTitles.Add(MapJobTitleToDTO(item));
            }

            return result;
        }
        public ResultStatus CreateJobTitle(string jobTitleName)
        {
            var entity = _repository.GetByName(jobTitleName);
            if (entity != null)
            {
                return ResultStatus.AlreadyExisted;
            }

            var result = _repository.Create(new JobTitleEntity(jobTitleName));
            if (result)
            {
                return ResultStatus.Created;
            }

            return ResultStatus.Error;

        }
        public ResultStatus DeleteJobTitle(int jobTitleId)
        {
            var entity = _repository.GetById(jobTitleId);
            if (entity == null) 
            {
                return ResultStatus.NotExisted;
            }
            _repository.Delete(jobTitleId);

            return ResultStatus.Deleted;
        }
        public ResultStatus UpdateJobTitle(int jobTitleId, string jobTitleName)
        {
            var entity = _repository.GetById(jobTitleId);
            if (entity == null)
            {
                return ResultStatus.NotExisted;
            }
            entity.Name = jobTitleName;

            var result = _repository.Update(entity);
            if (result)
            {
                return ResultStatus.Updated;
            }

            return ResultStatus.Error;
        }
        private JobTitleDTO MapJobTitleToDTO(JobTitleEntity? jobTitle, ResultStatus resultStatus = ResultStatus.Ok)
        {
            return new JobTitleDTO
            {
                Id = jobTitle != null ? jobTitle.Id : default,
                Name = jobTitle != null ? jobTitle.Name : String.Empty,
                ResultStatus = resultStatus
            };
        }
    }
}
