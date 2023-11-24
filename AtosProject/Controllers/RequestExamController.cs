using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Data_Models;
using System.Security.Claims;

namespace APIs_layer.Controllers
{
    [Authorize(Roles = "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestExamController : ControllerBase
    {
        private readonly IRequestExamSevice _requestExamSevice;

        public RequestExamController(IRequestExamSevice requestExamSevice)
        {
            _requestExamSevice = requestExamSevice;

        }
        [HttpPost("{SubjectId}")]
        public IActionResult RequestExam(int SubjectId)
        {
           
            try
            {
                var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var studentExamination = _requestExamSevice.RequestExam(SubjectId , studentId);
                return Ok(studentExamination);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        }
}
