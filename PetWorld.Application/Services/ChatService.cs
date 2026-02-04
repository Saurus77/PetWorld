using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Application.DTO;
using PetWorld.Application.Orchestration;
using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly WriterCriticOrchestrator _orchestrator;

        public ChatService(
            WriterCriticOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public async Task<ChatResponse> AskAsync(string question)
        {
            var chatEntry = await _orchestrator.ExecuteAsync(question);

            return new ChatResponse
            {
                Answer = chatEntry.Answer,
                Iterations = chatEntry.Iterations
            };
        }
    }
}
