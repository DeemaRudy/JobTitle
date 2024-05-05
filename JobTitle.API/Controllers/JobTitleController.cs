using JobTitle.BLL.DTO;
using JobTitle.BLL.Enums;
using JobTitle.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobTitleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleService _jobTitleService;
        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobTitleBase>> GetJobTitles()
        {
            var result = _jobTitleService.GetJobTitles();
            if (result?.ResultStatus == ResultStatus.Ok)
            {
                return Ok(result.jobTitles);
            }

            return NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult<JobTitleBase> GetJobTitle(int id)
        {
            var jobTitle = _jobTitleService.GetJobTitleById(id);
            if (jobTitle == null)
            {
                return NotFound();
            }
            if (jobTitle.ResultStatus == ResultStatus.Ok)
            {
                return Ok(jobTitle);
            }

            return NotFound();
        }
        [HttpPost("{jobTitleName}")]
        public IActionResult PostJobTitle(string jobTitleName)
        {
            var result = _jobTitleService.CreateJobTitle(jobTitleName);

            return ParseResultMessage(result);
        }
        [HttpPut("{id},{jobTitleName}")]
        public IActionResult PutJobTitle(int id, string jobTitleName)
        {
            var result = _jobTitleService.UpdateJobTitle(id, jobTitleName);

            return ParseResultMessage(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteJobTitle(int id)
        {
            var result = _jobTitleService.DeleteJobTitle(id);

            return ParseResultMessage(result);
        }

        private IActionResult ParseResultMessage(ResultStatus resultStatus)
        {
            switch (resultStatus)
            {
                case ResultStatus.Ok: return Ok();
                case ResultStatus.Created: return Created();
                case ResultStatus.Updated: return NoContent();
                case ResultStatus.Deleted: return NoContent();
                case ResultStatus.NotExisted: return NotFound();
                case ResultStatus.AlreadyExisted: return Conflict();
                case ResultStatus.Error: return StatusCode(500);
                default: return Ok();
            }
        }
    }
}
