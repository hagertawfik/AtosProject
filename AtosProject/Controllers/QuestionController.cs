using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs_layer.Controllers
{
    [Authorize(Roles = "admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionsService _questionFormService;
        public QuestionController(IQuestionsService questionFormService)
        {
            _questionFormService = questionFormService;
        }

        [HttpPost("questionForm")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
     public IActionResult  AddQuestionForm(int subjectId, [FromBody] QuestionFormDto questionFormDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState); 
                _questionFormService.AddQuestionForm(subjectId, questionFormDto);
                    return Ok("Questions added to subject successfuly "); 
                 
            }catch (Exception ex) { return BadRequest(ex.Message); }
            
               
        }

    }
}
