using PetWorld.Application.Agents;
using PetWorld.Application.Services;
using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Orchestration
{
    /// <summary>
    /// Klasa odpowiedzialna za orkiestrację procesu Writer-Critic.
    /// Steruje przepływem:
    /// 1. Writer generuje odpowiedź
    /// 2. Critic ocenia odpowiedź
    /// 3. Powtarza proces maksymalnie 3 razy lub do zatwierdzenia
    /// 4. Zapisuje finalną odpowiedź do historii czatu
    /// </summary>
    public class WriterCriticOrchestrator
    {
        // Maksymalna liczba iteracji Writer-Critic
        private const int MaxIterations = 3;

        private readonly IWriterAgent _writer;
        private readonly ICriticAgent _critic;
        private readonly IProductRepository _productRepository;
        private readonly IChatHistoryService _chatHistoryService;

        /// <summary>
        /// Konstruktor wstrzykujący wszystkie zależności.
        /// </summary>
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


        /// <summary>
        /// Wykonuje pełny proces Writer-Critic dla podanego pytania.
        /// </summary>
        /// <param name="question">Pytanie zadane przez klienta</param>
        /// <returns>Obiekt ChatHistoryEntry zawierający finalną odpowiedź i liczbę iteracji</returns>
        public async Task<ChatHistoryEntry> ExecuteAsync(string question)
        {
            // Pobranie wszystkich produktów z repozytorium
            var products = await _productRepository.GetAllAsync();

            // Feedback od Critica (opcjonalny), początkowo null
            string? feedback = null;

            // Finalna odpowiedź, będzie nadpisywana w każdej iteracji
            string finalAnswer = string.Empty;

            // Licznik iteracji
            int iterationCount = 0;

            // Pętla iteracyjna Writer-Critic
            for (iterationCount = 1; iterationCount <= MaxIterations; iterationCount++)
            {
                // Wywołanie Writer Agenta, przekazanie pytania, produktów i feedbacku
                var writerResult = await _writer.GenerateAnswerAsync(question, products, feedback);
                finalAnswer = writerResult.Answer;

                // Wywołanie Critic Agenta, ocena odpowiedzi
                var critique = await _critic.EvaluateAsync(question, finalAnswer);

                if (critique.Approved)
                    break;

                feedback = critique.Feedback;
            }

            // Tworzenie wpisu historii czatu
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
