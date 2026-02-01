using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;
using PetWorld.Application.Agents;
using PetWorld.Domain.Entities;
using PetWorld.Infrastructure.Configuration;

namespace PetWorld.Infrastructure.Agents
{
    public class WriterAgent : IWriterAgent
    {
        private readonly AIAgent _agent;

        public WriterAgent(IOptions<OpenAISettings> openAISettings)
        {
            var apiKey = openAISettings.Value.ApiKey;
            var modelName = openAISettings.Value.ModelName;

            _agent = new OpenAIClient(apiKey)
                .GetChatClient(modelName)
                .AsAIAgent(instructions: "Odpowiadaj klientowi jasno i pomocnie. Polecaj produkty z katalogu.", name: "Writer");

        }

        public async Task<string> GenerateAnswerAsync(string question,
            IReadOnlyList<Product> products,
            string? criticFeedback = null)
        {
            var productList = string.Join("\n", products.Select(p => $"{p.Name} ({p.Category}) - {p.Price} zł: {p.Description}"));

            var prompt = $"Pytanie klienta: {question}\nProdukty:\n{productList}";

            if(!string.IsNullOrEmpty(criticFeedback))
            {
                prompt += $"\nPoprzedni feedback: {criticFeedback}";
            }

            var response = await _agent.RunAsync(prompt);
            return response.Text;
        }

    }
}
