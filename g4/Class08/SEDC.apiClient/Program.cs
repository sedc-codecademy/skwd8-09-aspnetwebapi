using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SEDC.apiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            string url = "http://localhost:50639/api/notes";
            string token =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3RVc2VyIiwibmFtZWlkIjoiMyIsInVzZXJGdWxsTmFtZSI6IlRlc3QgVXNlciIsIm5iZiI6MTYwMjkyMzg4NywiZXhwIjoxNjAzNTI4Njg3LCJpYXQiOjE2MDI5MjM4ODd9.r8iMPnPvdvFDQkO6NQMm0pVq4azbivdC5nLuTWpV1b4";
            //add Authorization header
            httpClient.DefaultRequestHeaders.Authorization=
                new AuthenticationHeaderValue("Bearer", token);
            //http response
            HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
            //read the body as string
            string responseBody = responseMessage.Content.ReadAsStringAsync().Result;

            //to-do deserialize the json into List<Note>
        }
    }
}
