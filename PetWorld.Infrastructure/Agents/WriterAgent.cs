using Microsoft.Agents.AI;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Responses;
using PetWorld.Application.Agents;
using PetWorld.Domain.Entities;

namespace PetWorld.Infrastructure.Agents
{
    /// <summary>
    /// Implementacja agenta Writer, który generuje odpowiedzi dla klientów.
    /// Wysyła pytanie i listę produktów do AI i zwraca wynik w postaci WriterResult.
    /// </summary>
    public class WriterAgent : IWriterAgent
    {
        // AIAgent z Microsoft Agent Framework
        private readonly AIAgent _agent;

        /// <summary>
        /// Konstruktor tworzy agenta Writer i konfiguruje połączenie z OpenAI.
        /// </summary>
        public WriterAgent()
        {
            // Pobranie klucza API z systemowej zmiennej środowiskowej
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                ?? throw new InvalidOperationException("OPENAI_API_KEY environment variable is not set.");

            // Model OpenAI do generowania odpowiedzi
            var modelName = "gpt-3.5-turbo";

            var chatClient = new OpenAIClient(apiKey).GetChatClient(modelName);

            // Utworzenie agenta z instrukcjami
            _agent = chatClient.AsAIAgent(instructions:
                "Jesteś WriterAgentem. " +
                "Odpowiadaj po polsku w sposób jasny," +
                "konkretny i poprawny merytorycznie na pytanie użytkownika." +
                "Korzystaj tylko i wyłącznie ze znaków, liter i symboli zgodnych ze standardem UTF-8",
                name: "Writer");
        }


        /// <summary>
        /// Generuje odpowiedź dla klienta na podstawie pytania, listy produktów i opcjonalnego feedbacku Critica.
        /// </summary>
        /// <param name="question">Pytanie klienta</param>
        /// <param name="products">Lista dostępnych produktów</param>
        /// <param name="criticFeedback">Opcjonalny feedback od Critica</param>
        /// <returns>Obiekt WriterResult zawierający odpowiedź i rekomendowane produkty</returns>
        public async Task<WriterResult> GenerateAnswerAsync(
            string question,
            IReadOnlyList<Product> products,
            string? criticFeedback = null)
        {
            // Tworzenie tekstowej listy produktów dla promptu
            var productList = string.Join("\n", products.Select(p =>
                $"- {p.Name}: {p.Description} ({p.Category}, {p.Price} zł)"));

            // Tworzenie promptu dla AI
            var prompt =
                $"""
                Customer question:
                {question}

                Available products:
                {productList}

                {(criticFeedback is null ? "" : $"Critic feedback: {criticFeedback}")}
                """;

            // Wysłanie promptu do agenta i oczekiwanie na wynik
            var completion = await _agent.RunAsync([ new UserChatMessage(prompt) ]);

            // Pobranie ostatniego tekstu z odpowiedzi AI
            var answer = completion.Content.Last().Text.Trim();

            // Zwrócenie odpowiedzi wraz z listą produktów
            return new WriterResult
            (
                answer,
                products
            );
        }
    }
}
