using Application_Layer.BussinesLogicInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIs_layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamHistoryController : ControllerBase
    {
        private readonly IExamResultService _examResultService;

        public ExamHistoryController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

       // [Authorize(Roles = "admin")]
        [HttpGet("AllExamsHistory")]
        public IActionResult GetExamHistory(int page, int pageSize)
        {
            try
            {
                var examHistory = _examResultService.GetAllExamHistory( page,  pageSize);
                return Ok(examHistory);
            }catch (Exception ex) { return  BadRequest(ex.Message); }
           
        }

        [Authorize(Roles = "student")]
        [HttpGet("StudentExamHistory")]
        public IActionResult GetStudentExamHistory(int page, int pageSize)
        {
             
            try
            {
                var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var examHistory = _examResultService.GetStudentExamHistory(studentId, page, pageSize);
                  return Ok(examHistory);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
