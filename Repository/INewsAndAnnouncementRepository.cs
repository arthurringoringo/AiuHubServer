using AiuHubServer.Repository.DTOs;
using System;
using AiuHubServer.Infrastructure.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiuHubServer.Repository
{
    public interface INewsAndAnnouncementRepository
    {
        public string AddItem(NewsAndAnnouncement Item);
        public List<NewsAndAnnouncement> GetAllItem();
        public List<NewsAndAnnouncement> GetItemById(int ID);
        public List<NewsAndAnnouncement> GetItemByDate(DateTime DateTime);
        public List<NewsAndAnnouncement> GetItemBySource(String Source);


    }
}