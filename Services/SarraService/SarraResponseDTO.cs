using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiuHubServer.Infrastructure.Entity;
namespace AiuHubServer.Services.SarraService
{
    public class SarraListNews
    {
        public List<NewsAndAnnouncement> ListNews { get; set; }

    }

    public class SarraNewsDto
    {
        public int PostId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string Link { get; set; }
        public string ImageURL { get; set; }
        public string FormmatedDate { get; set; }

    }
        
}
