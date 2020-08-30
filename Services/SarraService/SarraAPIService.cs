using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AiuHubServer.Services;
using AiuHubServer.Services.SarraService;
using AiuHubServer.Infrastructure.Entity;

namespace AiuHubServer.Services.SarraService
{
    public class SarraAPIService : ISarraAPIService
    {
        private readonly INewsAndAnnouncementService _NewsAndAnnouncementService;
        
        private readonly HttpClient _client = new HttpClient();
        public SarraAPIService( INewsAndAnnouncementService newsAndAnnouncementService)
        {
            _NewsAndAnnouncementService = newsAndAnnouncementService;

        }
        public HttpClient CreateHttpClient()
        {
            var httpClient = _client;

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            return httpClient;
        }



        public  string Run()
        {
            List<SarraNewsDto> result = new List<SarraNewsDto>();
            
            result =  GetNews();

            int succes = 0;

            foreach (var item in result)
            {
              var succesCode =  _NewsAndAnnouncementService.SarraToDb(item);

                if (succesCode.Equals("Success"))
                {
                    succes++;
                }
            }
            return $"{succes} News sucess added to DB";
        }


        public List<SarraNewsDto> GetNews()
        {
            var uri = @"https://api.apiu.edu/api/news/latest";

            List<SarraNewsDto> result = new List<SarraNewsDto>();

            var Client = CreateHttpClient();
            try
            {
                var SarraHttpResponse = Client.GetAsync(uri).Result;

                if (SarraHttpResponse.IsSuccessStatusCode)
                {
                    var SarraResponseBody = SarraHttpResponse.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrWhiteSpace(SarraResponseBody))
                    {

                        result = JsonConvert.DeserializeObject<List<SarraNewsDto>>(SarraResponseBody);

                    }


                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                
            }

            return result;
        }

    }
}
