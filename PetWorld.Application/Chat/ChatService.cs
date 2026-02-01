using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Application.WriterCritic;

namespace PetWorld.Application.Chat
{
    public class ChatService : IChatService
    {
        private readonly WriterCriticOrechstrator _orchestrator;

        public ChatService(WriterCriticOrechstrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public async Task<ChatResponse> AskAsync(ChatRequest request)
        {
            var (answer, iterations) = await _orchestrator.RunAsync(request.Question);
            return new ChatResponse(answer, iterations);
        }
    }
}
