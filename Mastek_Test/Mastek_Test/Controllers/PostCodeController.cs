using Microsoft.AspNetCore.Mvc;

namespace Mastek_Test.Controllers
{
    public class PostCodeController : Controller
    {
        [HttpGet]
        [Route("api/PostCode")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
