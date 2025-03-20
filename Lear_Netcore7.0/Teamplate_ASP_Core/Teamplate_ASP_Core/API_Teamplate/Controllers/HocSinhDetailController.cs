using Data;
using Microsoft.AspNetCore.Mvc;

namespace API_Teamplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HocSinhDetailController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpGet(Name = "GetHocSinhDetail")]
        [HttpGet]
        public HocSinhDetail Get()
        {
            return new HocSinhDetail() { Name = "Hs 00001 Ne!"};
        }

        [HttpGet("{id}")]
        public HocSinhDetail Get(int id)
        {
            return new HocSinhDetail() { Name = "Get hoc sinh by ID!" };
        }
    }
}
