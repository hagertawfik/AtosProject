using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace APIs_layer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly IloginService _loginservice;
        public AuthenticationController(IRegisterService registerService, IloginService loginservice)
        {
            _registerService = registerService;
            _loginservice = loginservice;

        }


        [HttpPost]
        [Route("registeration")]
        public async Task<IActionResult> Register([FromBody] StudentRegistrationRequestDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(500, "Invalid payload");
                var authResults = await _registerService.Registeration(model);
                if (authResults.Result == false)
                {
                    return StatusCode(500,authResults);
                }
                return Ok(authResults);

            }
            catch (Exception ex)
            {
            
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var authResults = await _loginservice.Login(model);
                if (authResults.Result == false)
                    return BadRequest(authResults);
                return Ok(authResults);
            }
            catch (Exception ex)
            {
                  return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

