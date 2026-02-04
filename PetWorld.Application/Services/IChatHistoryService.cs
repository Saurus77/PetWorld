using PetWorld.Domain.Entities;

namespace PetWorld.Application.Services
{
    /// <summary>
    /// Interfejs definiujący kontrakt dla serwisu historii czatu.
    /// Każda implementacja powinna umożliwiać dodawanie wpisów
    /// oraz pobieranie wszystkich wpisów historii czatu.
    /// </summary>
    public interface IChatHistoryService
    {
        /// <summary>
        /// Dodaje nowy wpis historii czatu.
        /// </summary>
        /// <param name="entry">Wpis historii czatu do dodania</param>
        /// <returns>Task reprezentujący operację asynchroniczną</returns>
        Task AddAsync(ChatHistoryEntry entry);

        /// <summary>
        /// Pobiera wszystkie wpisy historii czatu.
        /// </summary>
        /// <returns>Lista wszystkich wpisów historii czatu</returns>
        Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync();
    }
}
