using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Application.Abstractions.AI;

namespace PetWorld.Application.WriterCritic
{
    public class WriterCriticOrechstrator
    {
        private const int MaxIterations = 3;

        private readonly IWriterAgent _writer;
        private readonly ICriticAgent _critic;

        public WriterCriticOrechstrator(
            IWriterAgent writer, ICriticAgent critic)
        {
            _writer = writer;
            _critic = critic;
        }

        public async Task<(string answer, int iterations)> RunAsync(string question)
        {
            string currentAnswer = string.Empty;

            for(int i = 1; i<= MaxIterations; i++)
            {
                var writerResult = await _writer.WriteAsync(question);
                currentAnswer = writerResult.Answer;

                var criticResult = await _critic.CritiqueAsync(question, currentAnswer);

                if (criticResult.Approved)
                {
                    return (currentAnswer, i);
                }
            }

            return (currentAnswer, MaxIterations);
        }

    }
}
