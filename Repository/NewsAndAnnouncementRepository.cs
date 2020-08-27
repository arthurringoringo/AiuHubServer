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

        public async Task<string> AddItem(NewsAndAnnouncement Item)
        {
            var response = string.Empty;
            try
            {
                Item.CreatedOn = DateTime.UtcNow;

                _context.NewsAndAnnouncement.Add(Item);

                await _context.SaveChangesAsync();

                response = "Success";

                return response;
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }

        public async Task<List<NewsAndAnnouncement>> GetAllItem()
        {
            var result = _context.NewsAndAnnouncement.ToListAsync();

            return await result;
        }

        public async Task<List<NewsAndAnnouncement>> GetItemByDate(DateTime DateTime)
        {
            var result = _context.NewsAndAnnouncement.Where(m => m.PostedDate == DateTime || m.CreatedOn == DateTime).ToListAsync();

            return await result;
        }

        public async Task<List<NewsAndAnnouncement>> GetItemById(Guid ID)
        {
            var result = _context.NewsAndAnnouncement.Where(m => m.Id == ID).ToListAsync();

            return await result;
        }

        public async Task<List<NewsAndAnnouncement>> GetItemBySource(string Source)
        {
           var result = _context.NewsAndAnnouncement.Where(m => m.Source == Source).ToListAsync(); 

            return await result;
        
        }
    }
}
