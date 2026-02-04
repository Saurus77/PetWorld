using PetWorld.Domain.Entities;

namespace PetWorld.Domain.Repositories
{
    /// <summary>
    /// Interfejs definiujący kontrakt repozytorium historii czatu.
    /// Znajduje się w warstwie Domain, aby zachować separację zależności.
    /// </summary>
    public interface IChatHistoryRepository
    {
        /// <summary>
        /// Dodaje nowy wpis historii czatu do repozytorium.
        /// </summary>
        /// <param name="entry">Wpis historii czatu do zapisania</param>
        /// <returns>Task reprezentujący operację asynchroniczną</returns>
        Task AddAsync(ChatHistoryEntry entry);

        /// <summary>
        /// Pobiera wszystkie wpisy historii czatu.
        /// </summary>
        /// <returns>Lista wszystkich wpisów historii czatu</returns>
        Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync();
    }
}
