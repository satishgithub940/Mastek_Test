using Mastek.Model.PostCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCodeAPI.Services
{
    public interface IPostCodeAPIService 
    {
        PostcodeAPIResponseDbo GetPostCodeDetail(string postCode);
    }
}
