using Application_Layer.BussinesLogicInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Data_Models;
using System.Security.Claims;

namespace APIs_layer.Controllers
{

    [Authorize(Roles = "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudentSubjectService _studentSubjectService;
        public StudentSubjectController(IStudentSubjectService studentSubjectService)
        {
            _studentSubjectService = studentSubjectService;
        }

        // Add new student subject
        [HttpPost("addnewStudentSubject/{subjectId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddNewStudentSubject( int subjectId)
        {
            
            try
            {
                 var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
               
                if (_studentSubjectService.AddNewStudentSubject(studentId, subjectId))
                    return Ok("subject added to the student successfuly");

                return BadRequest("something went wrong");
            }
            catch (Exception ex)
            {
             return  StatusCode(500, ex.Message);
            }
        }

        // get all student subjects
        [HttpGet("getStudentSubjects")]
        public IActionResult GetStudentSubjects()
        {
            
            try
            {
                var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var studentSubjects = _studentSubjectService.GetStudentSubjects(studentId);
                return Ok(studentSubjects);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("getanotherSubjects")]
        public IActionResult GetSubjectSudentdoesnotrole()
        {

            try
            {
                var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var studentSubjects = _studentSubjectService.GetSubjectSudentdoesnotrole(studentId);
                return Ok(studentSubjects);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}
