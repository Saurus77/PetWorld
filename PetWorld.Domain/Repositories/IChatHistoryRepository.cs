using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Domain.Entities;

namespace PetWorld.Domain.Repositories
{
    // Interfejs repozytorium historii czatu
    public interface IChatHistoryRepository
    {
        // Dodaje nową sesję czatu asynchronicznie
        Task AddAsync(ChatHistoryEntry session);

        // Pobiera wszystkie wpisy historii czatu jako listę tylko do odczytu asynchronicznie
        Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync();
    }
}
