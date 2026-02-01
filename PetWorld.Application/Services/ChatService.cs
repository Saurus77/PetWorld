using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Application.Orchestration;
using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly WriterCriticOrchestrator _orchestrator;
        private readonly IChatHistoryRepository _chatHistoryRepository;

        public ChatService(
            WriterCriticOrchestrator orchestrator,
            IChatHistoryRepository chatHistoryRepository)
        {
            _orchestrator = orchestrator;
            _chatHistoryRepository = chatHistoryRepository;
        }

        public async Task<ChatResponse> AskAsync(string question)
        {
            var (answer, iterations) = await _orchestrator.ExecuteAsync(question);
            var chatEntry = new ChatHistoryEntry
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Question = question,
                Answer = answer,
                Iterations = iterations
            };

            await _chatHistoryRepository.AddAsync(chatEntry);

            return new ChatResponse
            {
                Answer = answer,
                Iterations = iterations
            };
        }
    }
}
