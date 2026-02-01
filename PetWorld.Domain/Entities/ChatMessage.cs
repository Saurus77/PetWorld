using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Domain.Enums;

namespace PetWorld.Domain.Entities
{
    public class ChatMessage
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public ChatRole Role { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        protected ChatMessage() { }
        public ChatMessage(ChatRole role, string content)
        {
            Role = role;
            Content = content;
        }
    }
}
