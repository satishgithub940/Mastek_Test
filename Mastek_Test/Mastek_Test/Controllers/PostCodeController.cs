using Mastek.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostCode.Services.PostCode;
using System.Net;

namespace Mastek_Test.Controllers
{
    public class PostCodeController : ControllerBase
    {
        public static IPostCodeService _postCode;

        #region Constructor
        public PostCodeController(IPostCodeService postCode) 
        { _postCode = postCode; }
        #endregion

        #region Public API Methods
        [HttpGet]
        [Route("api/PostCode/")]
        public IActionResult GetAreaByPostCode([FromQuery] string postCode)
        {
            if (string.IsNullOrEmpty(postCode))
            {
                return Ok(new ErrorResponse() { StatusCode = HTTPStatusCode.BadRequest.ToString(), Message = Constants.Msg_InvalidpostCode });
            }
            var result = _postCode.GetAreaDetailByPostCode(postCode);
            if (result != null)
            {
                return Ok(_postCode.GetAreaDetailByPostCode(postCode));
            }
            else
            {
                return Ok(new ErrorResponse() { StatusCode = HTTPStatusCode.NotFound.ToString(), Message = Constants.Msg_PostCodeNotFound });
            }

        }
        #endregion
    }
}
