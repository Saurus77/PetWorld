using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.OpenAI;
using Microsoft.Agents.Core;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Responses;
using PetWorld.Application.Agents;
using PetWorld.Domain.Entities;

namespace PetWorld.Infrastructure.Agents
{
    public class WriterAgent : IWriterAgent
    {

        private  readonly AIAgent _agent;

        public WriterAgent()
        {
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                ?? throw new InvalidOperationException("OPENAI_API_KEY environment variable is not set.");
            var modelName = "gpt-3.5-turbo";

            var chatClient = new OpenAIClient(apiKey).GetChatClient(modelName);

            _agent = chatClient.AsAIAgent(instructions:
                "Jesteś WriterAgentem. " +
                "Odpowiadaj po polsku w sposób jasny," +
                "konkretny i poprawny merytorycznie na pytanie użytkownika." +
                "Korzystaj tylko i wyłącznie ze znaków, liter i symboli zgodnych ze standardem UTF-8",
                name: "Writer");
        }


        public async Task<WriterResult> GenerateAnswerAsync(
            string question,
            IReadOnlyList<Product> products,
            string? criticFeedback = null)
        {
            var productList = string.Join("\n", products.Select(p =>
                $"- {p.Name}: {p.Description} ({p.Category}, {p.Price} zł)"));

            var prompt =
                $"""
                Customer question:
                {question}

                Available products:
                {productList}

                {(criticFeedback is null ? "" : $"Critic feedback: {criticFeedback}")}
                """;

            var completion = await _agent.RunAsync([ new UserChatMessage(prompt) ]);

            var answer = completion.Content.Last().Text.Trim();

            return new WriterResult
            (
                answer,
                products
            );
        }
    }
}
