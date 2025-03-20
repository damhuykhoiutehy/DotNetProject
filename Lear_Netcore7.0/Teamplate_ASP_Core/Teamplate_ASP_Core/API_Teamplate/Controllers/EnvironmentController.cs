using Microsoft.AspNetCore.Mvc;

namespace API_Teamplate.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EnvironmentController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult GetEnvironment()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return Ok(new { Environment = environment });
        }
    }
}
