using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetWorld.Application.Services
{
    public class ChatHistoryService : IChatHistoryService
    {
        private readonly IChatHistoryRepository _repository;
        public ChatHistoryService(IChatHistoryRepository repository)
        {
            _repository = repository;
        }

        public Task AddAsync(ChatHistoryEntry entry) => _repository.AddAsync(entry);
        public Task<IReadOnlyList<ChatHistoryEntry>> GetAllAsync() => _repository.GetAllAsync();
    }
}
