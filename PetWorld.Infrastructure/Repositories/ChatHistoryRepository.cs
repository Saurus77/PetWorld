using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;
using PetWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PetWorld.Infrastructure.Repositories
{
    public class ChatHistoryRepository : IChatHistoryRepository
    {
        private readonly PetWorldDbContext _context;
        public ChatHistoryRepository(PetWorldDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChatHistoryEntry entry)
        {
            _context.ChatHistory.Add(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync() =>
            await _context.ChatHistory
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
    }
}
