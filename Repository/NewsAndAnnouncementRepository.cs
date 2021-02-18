 using AiuHubServer.Infrastructure.DataContext;
using AiuHubServer.Repository.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiuHubServer.Infrastructure.Entity;
using Microsoft.AspNetCore.Http;

namespace AiuHubServer.Repository
{
    public class NewsAndAnnouncementRepository : INewsAndAnnouncementRepository
    {
        private readonly ServerDBContext _context;

        public NewsAndAnnouncementRepository(ServerDBContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public string AddItem(NewsAndAnnouncement Item)
        {
            var response = string.Empty;
            try
            {

                _context.NewsAndAnnouncement.Add(Item);

               _context.SaveChanges();

                response = "Success";

                return response;
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }

        public List<NewsAndAnnouncement> GetAllItem()
        {
                var result = _context.NewsAndAnnouncement.OrderByDescending(x => x.PostID).ToList();

            return result;
        }

        public List<NewsAndAnnouncement> GetItemByDate(DateTime DateTime)
        {
            var result = _context.NewsAndAnnouncement.Where(m => m.PostedDate == DateTime || m.CreatedOn == DateTime).ToList();

            return result;
        }

        public List<NewsAndAnnouncement> GetItemById(int ID)
        {
            var result = _context.NewsAndAnnouncement.Where(m => m.PostID == ID).ToList();

            return result;
        }

        public List<NewsAndAnnouncement> GetItemBySource(string Source)
        {
           var result = _context.NewsAndAnnouncement.Where(m => m.Source == Source).ToList(); 

            return result;
        
        }
    }
}
