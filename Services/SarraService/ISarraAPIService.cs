using AiuHubServer.Infrastructure.Entity;
using System.Collections.Generic;

namespace AiuHubServer.Services.SarraService
{
    public interface ISarraAPIService
    {
        public List<SarraNewsDto> Run();
    }
}