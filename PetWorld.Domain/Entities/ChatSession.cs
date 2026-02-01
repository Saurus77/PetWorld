using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Domain.Entities
{
    // Encja sesji agreguje wiadomości czatu
    public class ChatSession
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime StartedAt { get; private set; } = DateTime.UtcNow;

        private readonly List<ChatMessage> _messages = new();
        public IReadOnlyCollection<ChatMessage> Messages => _messages.AsReadOnly();

        protected ChatSession() { }

        public void AddMessage(ChatMessage message)
        {
            _messages.Add(message);
        }
    }
}
