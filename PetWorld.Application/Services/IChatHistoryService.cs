using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Domain.Entities;

namespace PetWorld.Application.Services
{
    public interface IChatHistoryService
    {
        Task AddAsync(ChatHistoryEntry entry);
        Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync();
    }
}
