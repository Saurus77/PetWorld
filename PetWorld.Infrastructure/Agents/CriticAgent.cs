using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using OpenAI;
using OpenAI.Chat;
using PetWorld.Application.Agents;
using PetWorld.Domain.Entities;

namespace PetWorld.Infrastructure.Agents
{
    public class CriticAgent : ICriticAgent
    {
        private readonly AIAgent _agent;

        public CriticAgent()
        {
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                ?? throw new InvalidOperationException("OPENAI_API_KEY environment variable is not set.");
            var modelName = "gpt-3.5-turbo";

            var chatClient = new OpenAIClient(apiKey).GetChatClient(modelName);

            _agent = chatClient.AsAIAgent(instructions:
                "Jesteś CriticAgentem. " +
                "Oceń odpowiedź WriterAgenta pod kątem poprawności, kompletności i jasności." +
                "Zwróć wyłącznie APPROVED lub REJECTED oraz krótkie uzasadnieniem" +
                "Nie poprawiaj odpowiedzi WriterAgenta." +
                "Korzystaj tylko i wyłącznie ze znaków, liter i symboli zgodnych ze standardem UTF-8",
                name: "Critic");
        }


        public async Task<CriticResult> EvaluateAsync(string question, string answer)
        {
            var prompt = (
                  $"""
                Question:
                {question}

                Answer:
                {answer}

                Respond with:
                APPROVED or REJECTED and short feedback.
                """);
       

            var completion = await _agent.RunAsync([new UserChatMessage(prompt)]);

            var text = completion.Content.Last().Text.Trim();

            var approved = text.StartsWith("APPROVED", StringComparison.OrdinalIgnoreCase);

            return new CriticResult
            (
                approved,
                text
            );
        }
    }
}
