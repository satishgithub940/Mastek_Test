using Mastek.Model.PostCode;
using System;
using System.Net.Http;
using System.Text.Json;

namespace PostCodeAPI.Services
{
    public class PostCodeAPIService : IPostCodeAPIService
    {
        public PostcodeAPIResponseDbo  GetPostCodeDetail(string postCode)
        {
            string apiUrl = "https://api.postcodes.io/postcodes/"+ postCode;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
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
                    throw;
                }
            }
        }
    }
}
