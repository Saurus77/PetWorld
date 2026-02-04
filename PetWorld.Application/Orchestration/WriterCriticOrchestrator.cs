using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetWorld.Application.Agents;
using PetWorld.Application.Services;
using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Orchestration
{
    public class WriterCriticOrchestrator
    {
        private const int MaxIterations = 3;

        private readonly IWriterAgent _writer;
        private readonly ICriticAgent _critic;
        private readonly IProductRepository _productRepository;
        private readonly IChatHistoryService _chatHistoryService;

        public WriterCriticOrchestrator(
            IWriterAgent writer,
            ICriticAgent critic,
            IProductRepository productRepository,
            IChatHistoryService chatHistoryService)
        {
            _writer = writer;
            _critic = critic;
            _productRepository = productRepository;
            _chatHistoryService = chatHistoryService;
        }

        public async Task<ChatHistoryEntry> ExecuteAsync(string question)
        {
            var products = await _productRepository.GetAllAsync();
            string? feedback = null;
            string finalAnswer = string.Empty;
            int iterationCount = 0;

            for (iterationCount = 1; iterationCount <= MaxIterations; iterationCount++)
            {
                // Wywołanie Writer
                var writerResult = await _writer.GenerateAnswerAsync(question, products, feedback);
                finalAnswer = writerResult.Answer;

                // Wywołanie Critic
                var critique = await _critic.EvaluateAsync(question, finalAnswer);

                if (critique.Approved)
                    break;

                feedback = critique.Feedback;
            }

            // Zapis do historii czatu
            var chatEntry = new ChatHistoryEntry
            (
                question,
                finalAnswer,
                iterationCount
            );

            await _chatHistoryService.AddAsync(chatEntry);

            return chatEntry;
        }
    }
}
