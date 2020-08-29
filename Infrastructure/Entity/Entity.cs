using System;

namespace AiuHubServer.Infrastructure.Entity
{
    public class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        

    }
}
