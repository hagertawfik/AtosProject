using Application_Layer.BussinesLogicInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs_layer.Controllers
{
    [Authorize(Roles = "admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _StudentService;
        public StudentController(IStudentService IStudentService)
        {
            _StudentService = IStudentService;
            
        }

        // getAll 
        [HttpGet("getallstudents")]
       
        public IActionResult GetAllStudents(int page , int pageSize)
        {
            try
            {
                var students = _StudentService.GetAllStudents(page , pageSize);
                return Ok(students);
            }
            catch (Exception ex) { return StatusCode(500,ex.Message); }
        }


        [HttpPatch("updateIsActive/{studentid}/{isActive}")]
        public IActionResult UpdateIsActive(string studentid, bool isActive)
        {
            try
            {  
               if( _StudentService.UpdateIsActive(studentid, isActive))
                    return Ok("status changed");
               return BadRequest(ModelState);

            }
            catch (Exception ex) { return StatusCode(500,ex.Message); }
        }


    }
}
