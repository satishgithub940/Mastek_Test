using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastek.Model.PostCode
{
    public class PostCodeDbo
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string AdminDistrict { get; set; }
        public string ParliamentaryConstituency { get; set; }
        public string Area { get; set; }

        public static PostCodeDbo FromDto(PostcodeAPIResponseDbo postCodeDetail)
        {
            if(postCodeDetail !=null && postCodeDetail.result != null)
            {
                return new PostCodeDbo()
                {
                    Country = postCodeDetail.result.country,
                    Region = postCodeDetail.result.region,
                    AdminDistrict = postCodeDetail.result.admin_district,
                    ParliamentaryConstituency = postCodeDetail.result.parliamentary_constituency,
                    Area = postCodeDetail.result.nhs_ha,
                };

            }
            return null;
        }
    }
}
