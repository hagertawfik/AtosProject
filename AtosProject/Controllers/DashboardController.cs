using Application_Layer.BussinesLogicInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIs_layer.Controllers
{ 
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        { 
            _dashboardService = dashboardService;
        }
        [HttpGet]
        public IActionResult GetDashboardNumbers()
        {
            try
            {
                var numbers = _dashboardService.GetRequiredNumbers();
                return Ok(numbers);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }

    }
}
