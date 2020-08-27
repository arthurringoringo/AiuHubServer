using AiuHubServer.Repository;
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



    }
}
