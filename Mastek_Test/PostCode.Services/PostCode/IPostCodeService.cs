using Mastek.Model.PostCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCode.Services.PostCode
{
    public interface IPostCodeService
    {
        PostCodeDbo GetAreaDetailByPostCode(string postCode);
    }
}
