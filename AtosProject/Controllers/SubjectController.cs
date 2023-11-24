using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIs_layer.Controllers
{
    //[Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {


        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        // getAll 
        [HttpGet("getallsubjects")]
        public IActionResult GetAllSubjects()
        {
            try
            {
                var Reternedsubjects = _subjectService.GetAllSubjects();
                return Ok(Reternedsubjects);
            }
            catch (Exception ex) { return  StatusCode(500, ex.Message);  }
        }

        //add

        [HttpPost("addSubject")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddSubject([FromBody] SubjectRequestDto subjectcreate)
        {
            try
            {
                    if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                    var response = _subjectService.addSubject(subjectcreate);
                      return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updateSubject/{subjectId}")]
        public IActionResult UpdateSubject(int subjectId, [FromBody] SubjectRequestDto updatedSubjectDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if( _subjectService.UpdateSubject(subjectId, updatedSubjectDto))
                    return Ok("subject updated successfuly");
                return BadRequest("something went wrong");
            }
         
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
    }
    }

