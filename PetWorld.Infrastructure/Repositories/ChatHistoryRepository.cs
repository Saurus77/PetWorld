using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Infrastructure.Data;
using PetWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PetWorld.Domain.Repositories;

namespace PetWorld.Infrastructure.Repositories
{
    public class ChatHistoryRepository : IChatHistoryRepository
    {
        private readonly PetWorldDbContext _dbContext;

        public ChatHistoryRepository(PetWorldDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ChatHistoryEntry entry)
        {
            _dbContext.ChatHistory.Add(entry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync()
        {
            return await _dbContext.ChatHistory.AsNoTracking().ToListAsync();
        }

    }
}
