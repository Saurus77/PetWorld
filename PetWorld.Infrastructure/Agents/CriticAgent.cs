using Microsoft.Agents.AI;
using OpenAI;
using OpenAI.Chat;
using PetWorld.Application.Agents;


namespace PetWorld.Infrastructure.Agents
{
    /// <summary>
    /// Implementacja agenta Critic, który ocenia odpowiedzi Writer Agenta.
    /// Wysyła pytanie i odpowiedź do AI (OpenAI) i zwraca wynik w postaci CriticResult.
    /// </summary>
    public class CriticAgent : ICriticAgent
    {
        // AIAgent z Microsoft Agent Framework
        private readonly AIAgent _agent;

        /// <summary>
        /// Konstruktor tworzy agenta Critic i konfiguruje połączenie z OpenAI.
        /// </summary>
        public CriticAgent()
        {
            // Pobranie klucza API z systemowej zmiennej środowiskowej
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
                ?? throw new InvalidOperationException("OPENAI_API_KEY environment variable is not set.");

            // Model OpenAI do generowania ocen
            var modelName = "gpt-3.5-turbo";

            var chatClient = new OpenAIClient(apiKey).GetChatClient(modelName);

            // Utworzenie agenta z instrukcjami
            _agent = chatClient.AsAIAgent(instructions:
                "Jesteś CriticAgentem. " +
                "Oceń odpowiedź WriterAgenta pod kątem poprawności, kompletności i jasności." +
                "Zwróć wyłącznie APPROVED lub REJECTED oraz krótkie uzasadnieniem" +
                "Nie poprawiaj odpowiedzi WriterAgenta." +
                "Korzystaj tylko i wyłącznie ze znaków, liter i symboli zgodnych ze standardem UTF-8",
                name: "Critic");
        }


        /// <summary>
        /// Ocena odpowiedzi pod kątem poprawności i jasności.
        /// </summary>
        /// <param name="question">Pytanie klienta</param>
        /// <param name="answer">Odpowiedź wygenerowana przez Writer Agenta</param>
        /// <returns>Wynik oceny w postaci CriticResult</returns>
        public async Task<CriticResult> EvaluateAsync(string question, string answer)
        {
            // Prompt wysyłany do AI
            var prompt = (
                  $"""
                Question:
                {question}

                Answer:
                {answer}

                Respond with:
                APPROVED or REJECTED and short feedback.
                """);

            // Wysłanie promptu do agenta i oczekiwanie na wynik
            var completion = await _agent.RunAsync([new UserChatMessage(prompt)]);

            // Pobranie ostatniego tekstu z odpowiedzi AI
            var text = completion.Content.Last().Text.Trim();

            // Sprawdzenie, czy odpowiedź jest zatwierdzona
            var approved = text.StartsWith("APPROVED", StringComparison.OrdinalIgnoreCase);

            // Zwrócenie wyniku w CriticResult
            return new CriticResult
            (
                approved,
                text
            );
        }
    }
}
