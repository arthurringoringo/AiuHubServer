using System;

namespace AiuHubServer.Infrastructure.Entity
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedOn { get; set; }

    }
}
