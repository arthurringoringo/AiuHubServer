using AiuHubServer.Infrastructure.Entity;
using AiuHubServer.Infrastructure.Entity.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AiuHubServer.Infrastructure.DataContext
{
    public class ServerDBContext : DbContext
    {

        
        public DbSet<NewsAndAnnouncement> NewsAndAnnouncement {get; set;}


        public ServerDBContext(DbContextOptions<ServerDBContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsAndAnnouncementConfiguration());
        }

        public ServerDBContext NewInstance()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ServerDBContext>();
            dbContextOptionsBuilder.UseNpgsql(this.Database.GetDbConnection().ConnectionString);

            return new ServerDBContext(dbContextOptionsBuilder.Options);
        }


    }
}
