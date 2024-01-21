using Mastek.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostCode.Services.PostCode;

namespace Mastek_Test.Controllers
{
    public class PostCodeController : ControllerBase
    {
        public static IPostCode _postCode;
        public PostCodeController(IPostCode postCode) { _postCode = postCode; }
        [HttpGet]
        [Route("api/PostCode/")]
        public IActionResult GetAreaByPostCode([FromQuery] string postCode)
        {
            if (string.IsNullOrEmpty(postCode))
            {
                return Ok(new ErrorResponse() { StatusCode = "400", Message = "Invalid postCode" });
            }
            var result = _postCode.GetAreaDetailByPostCode(postCode);
            if (result != null)
            {
                return Ok(_postCode.GetAreaDetailByPostCode(postCode));
            }
            else
            {
                return Ok(new ErrorResponse() { StatusCode = "404", Message = "Detail not found for given postCode" });
            }

        }
    }
}
