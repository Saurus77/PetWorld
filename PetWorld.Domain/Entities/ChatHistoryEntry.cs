using System;

namespace PetWorld.Domain.Entities
{
    public class ChatHistoryEntry
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Question { get; private set; } = string.Empty;
        public string Answer { get; private set; } = string.Empty;
        public int Iterations { get; private set; }

        protected ChatHistoryEntry() { }

        public ChatHistoryEntry(string question, string answer, int iterations)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Question = question;
            Answer = answer;
            Iterations = iterations;
        }
    }
}
