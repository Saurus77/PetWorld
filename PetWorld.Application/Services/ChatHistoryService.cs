using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Services
{
    /// <summary>
    /// Serwis do obsługi historii czatu.
    /// Abstrakcyjnie pośredniczy między warstwą Application a repozytorium.
    /// </summary>
    public class ChatHistoryService : IChatHistoryService
    {
        // Repozytorium do przechowywania i pobierania wpisów historii czatu
        private readonly IChatHistoryRepository _repository;

        /// <summary>
        /// Konstruktor wstrzykujący zależność repozytorium.
        /// </summary>
        /// <param name="repository">Repozytorium historii czatu</param>
        public ChatHistoryService(IChatHistoryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Dodaje nowy wpis historii czatu do repozytorium.
        /// </summary>
        /// <param name="entry">Wpis historii czatu do zapisania</param>
        /// <returns>Task reprezentujący operację asynchroniczną</returns>
        public Task AddAsync(ChatHistoryEntry entry)
            => _repository.AddAsync(entry); // Delegacja do repozytorium

        /// <summary>
        /// Pobiera wszystkie wpisy historii czatu.
        /// </summary>
        /// <returns>Lista wszystkich wpisów historii czatu</returns>
        public Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync()
            => _repository.GetAllAsync(); // Delegacja do repozytorium
    }
}
