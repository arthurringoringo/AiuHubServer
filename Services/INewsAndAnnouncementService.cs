using AiuHubServer.Services.SarraService;
using System.Threading.Tasks;

namespace AiuHubServer.Services
{
    public interface INewsAndAnnouncementService
    {

        public string SarraToDb(SarraNewsDto item);
    
            
    }
}