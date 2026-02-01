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
using Newtonsoft.Json;

namespace PetWorld.Infrastructure.Agents
{
    public class CriticAgent : ICriticAgent
    {
        private readonly AIAgent _agent;

        public CriticAgent(IOptions<OpenAISettings> openAISettings)
        {
            var apiKey = openAISettings.Value.ApiKey;
            var modelName = openAISettings.Value.ModelName;

            _agent = new OpenAIClient(apiKey)
                .GetChatClient(modelName)
                .AsAIAgent(instructions: "Oceń odpowiedź klienta i zwróć JSON { approved: true/false, feedback: '...' }", name: "Critic");
        }

        public async Task<CriticResult> EvaluateAsync(string question, string answer)
        {
            var prompt = $"Pytanie: {question}\nOdpowiedź: {answer}\nZwróć JSON z approved i feedback.";

            var response = await _agent.RunAsync(prompt);

            var result = JsonConvert.DeserializeObject<CriticResult>(response.Text)
                ?? new CriticResult { Approved = false, Feedback = "Brak oceny" };

            return result;

        }
    }
}
