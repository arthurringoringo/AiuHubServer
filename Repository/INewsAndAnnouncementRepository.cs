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
        public Task<List<NewsAndAnnouncement>> GetAllItem();
        public Task<List<NewsAndAnnouncement>> GetItemById(Guid ID);
        public Task<List<NewsAndAnnouncement>> GetItemByDate(DateTime DateTime);
        public Task<List<NewsAndAnnouncement>> GetItemBySource(String Source);


    }
}