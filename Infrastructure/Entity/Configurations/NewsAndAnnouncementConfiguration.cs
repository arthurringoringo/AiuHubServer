using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AiuHubServer.Infrastructure.Entity.Configurations
{
    public class NewsAndAnnouncementConfiguration : IEntityTypeConfiguration<NewsAndAnnouncement>
    {
        public void Configure(EntityTypeBuilder<NewsAndAnnouncement> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}
