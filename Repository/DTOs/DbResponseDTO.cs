
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiuHubServer.Repository.DTOs
{
    public class AnnouncementList
    {
        public List<Announcement> Announcements { get; set; }
    }


    public class Announcement
    {
        public int PostID { get; set; }
        public string Source { get; set; }
        public DateTime PostedDate { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }
    }
}
