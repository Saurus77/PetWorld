using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Question = question;
            Answer = answer;
            Iterations = iterations;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
