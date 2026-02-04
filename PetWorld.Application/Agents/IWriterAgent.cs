using PetWorld.Domain.Entities;

namespace PetWorld.Application.Agents
{
    /// <summary>
    /// Interfejs definiujący kontrakt dla Writer Agenta.
    /// Każda implementacja powinna potrafić wygenerować odpowiedź na pytanie klienta
    /// z uwzględnieniem dostępnych produktów i ewentualnego feedbacku od Critica.
    /// </summary>
    public interface IWriterAgent
    {
        /// <summary>
        /// Asynchronicznie generuje odpowiedź dla klienta.
        /// </summary>
        /// <param name="question">Pytanie zadane przez klienta</param>
        /// <param name="products">Lista produktów, które agent może rekomendować</param>
        /// <param name="criticFeedback">
        /// Opcjonalny feedback od Critica. Jeśli odpowiedź była oceniona negatywnie,
        /// agent może poprawić odpowiedź bazując na tym feedbacku.
        /// </param>
        /// <returns>
        /// Obiekt <see cref="WriterResult"/> zawierający wygenerowaną odpowiedź
        /// i inne informacje potrzebne orchestratorowi.
        /// </returns>
        Task<WriterResult> GenerateAnswerAsync(
            string question,
            IReadOnlyList<Product> products,
            string? criticFeedback = null);
    }
}
