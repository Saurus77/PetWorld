using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Application.Agents;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Orchestration
{
    public class WriterCriticOrchestrator
    {
        private const int MaxIterations = 3;

        private readonly IWriterAgent _writer;
        private readonly ICriticAgent _critic;
        private readonly IProductRepository _productRepository;

        public WriterCriticOrchestrator(
            IWriterAgent writer,
            ICriticAgent critic,
            IProductRepository productRepository)
        {
            _writer = writer;
            _critic = critic;
            _productRepository = productRepository;
        }

        public async Task<(string Answer, int Iterations)> ExecuteAsync(string question)
        {
            var products = await _productRepository.GetAllAsync();
            string? feedback = null;
            string answer = string.Empty;

            for (int iteration = 1; iteration <= MaxIterations; iteration++)
            {
                answer = await _writer.GenerateAnswerAsync(
                    question,
                    products,
                    feedback);

                var critique = await _critic.EvaluateAsync(
                    question,
                    answer);

                if (critique.Approved)
                {
                    return (answer, iteration);
                }

                feedback = critique.Feedback;
            }
            return (answer, MaxIterations);
        }
    }
}
