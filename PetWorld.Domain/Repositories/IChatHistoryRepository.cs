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
        // Zapisuje sesję czatu asynchronicznie
        Task SaveAsync(ChatSession session);

        // Pobiera wszystkie sesje czatu jako listę tylko do odczytu asynchronicznie
        Task<IReadOnlyList<ChatSession>> GetAllAsync();
    }
}
