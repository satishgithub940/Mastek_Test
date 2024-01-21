using Mastek.Model.PostCode;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;

namespace PostCodeAPI.Services
{
    public class PostCodeAPIService : IPostCodeAPIService
    {
        public static IConfiguration _configuration;
        public PostCodeAPIService(IConfiguration configuration) { _configuration = configuration; }
        public PostcodeAPIResponseDbo  GetPostCodeDetail(string postCode)
        {
            
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = _configuration["ApiSettings:PostCodeApiUrl"] + postCode;
                    // Make a GET request
                    HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Read  the content of the response
                        string content = response.Content.ReadAsStringAsync().Result;
                        PostcodeAPIResponseDbo postDetail = JsonSerializer.Deserialize<PostcodeAPIResponseDbo>(content);
                        return postDetail;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
