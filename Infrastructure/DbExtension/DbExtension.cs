using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AiuHubServer.Infrastructure.DataContext;

namespace AiuHubServer.Infrastructure.DbExtension
{
    public static class DbExtension
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {

                using (var context = serviceScope.ServiceProvider.GetService<ServerDBContext>())
                {
                    context.Database.Migrate();
                }
            
            
            }
        

        }
    }
}
