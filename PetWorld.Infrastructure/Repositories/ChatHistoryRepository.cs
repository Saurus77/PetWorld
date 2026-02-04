using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;
using PetWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PetWorld.Infrastructure.Repositories
{
    /// <summary>
    /// Repozytorium historii czatu.
    /// Implementuje IChatHistoryRepository przy użyciu Entity Framework Core.
    /// </summary>
    public class ChatHistoryRepository : IChatHistoryRepository
    {
        private readonly PetWorldDbContext _context;

        /// <summary>
        /// Konstruktor repozytorium, przyjmujący DbContext.
        /// </summary>
        /// <param name="context">Kontekst bazy danych</param>
        public ChatHistoryRepository(PetWorldDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dodaje nowy wpis czatu do bazy danych.
        /// </summary>
        /// <param name="entry">Wpis historii czatu</param>
        public async Task AddAsync(ChatHistoryEntry entry)
        {
            _context.ChatHistory.Add(entry);    // Dodanie do DbSet
            await _context.SaveChangesAsync();  // Zapis zmian w bazie
        }

        /// <summary>
        /// Pobiera wszystkie wpisy historii czatu, posortowane od najnowszych.
        /// </summary>
        /// <returns>Lista wpisów historii czatu</returns>
        public async Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync() =>
            await _context.ChatHistory
                .OrderByDescending(c => c.CreatedAt)    // Sortowanie najnowszje -> najstarsze
                .ToListAsync();
    }
}
