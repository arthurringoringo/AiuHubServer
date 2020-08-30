using AiuHubServer.Infrastructure.Entity;
using AiuHubServer.Repository;
using AiuHubServer.Services.SarraService;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiuHubServer.Services
{
    public class NewsAndAnnouncementService : INewsAndAnnouncementService
    {
        private readonly INewsAndAnnouncementRepository _NewsAndAnnouncementRepository;

        public NewsAndAnnouncementService(INewsAndAnnouncementRepository newsAndAnnouncement)
        {
            _NewsAndAnnouncementRepository = newsAndAnnouncement ?? throw new ArgumentNullException(nameof(newsAndAnnouncement));
        
        }


        public string SarraToDb(SarraNewsDto item)
        {
            NewsAndAnnouncement news = new NewsAndAnnouncement();

            news.Id = new Guid();
            news.CreatedOn = DateTime.UtcNow;
            news.Title = item.Title;
            news.Source = "Sarra";
            news.PostedDate = Convert.ToDateTime(item.FormmatedDate);
            news.Heading = item.Excerpt;
            news.Content = item.Content;
            news.ImageLink = item.ImageURL;
            news.Link = item.Link;
            news.PostID = item.PostId;

            var result = string.Empty;
            try
            {
               result = _NewsAndAnnouncementRepository.AddItem(news);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return result;
        }



    }
}
