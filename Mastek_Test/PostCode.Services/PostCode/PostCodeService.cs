using Mastek.Model.PostCode;
using PostCodeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCode.Services.PostCode
{
    public class PostCodeService : IPostCodeService
    {
        public static IPostCodeAPIService _postCodeAPIService;
        public PostCodeService(IPostCodeAPIService postCodeAPIService)
        { _postCodeAPIService = postCodeAPIService; }
        public PostCodeDbo GetAreaDetailByPostCode(string postCode)
        {
            return PostCodeDbo.FromDto(_postCodeAPIService.GetPostCodeDetail(postCode));
        }
    }
}
