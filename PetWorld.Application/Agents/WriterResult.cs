using PetWorld.Domain.Entities;

namespace PetWorld.Application.Agents
{
    /// <summary>
    /// Reprezentuje wynik wygenerowany przez Writer Agenta.
    /// Zawiera odpowiedź dla klienta oraz opcjonalnie listę rekomendowanych produktów.
    /// </summary>
    public class WriterResult
    {
        /// <summary>
        /// Właściwa odpowiedź tekstowa wygenerowana przez agenta.
        /// </summary>
        public string Answer { get; set; } = string.Empty;

        /// <summary>
        /// Lista produktów rekomendowanych przez agenta (opcjonalnie).
        /// IReadOnlyList, aby uniemożliwić modyfikacje listy z zewnątrz.
        /// </summary>
        public IReadOnlyList<Product> RecommendedProducts { get; set; } = new List<Product>();

        /// <summary>
        /// Konstruktor chroniony, potrzebny np. do serializacji/deserializacji.
        /// </summary>
        protected WriterResult() { }

        /// <summary>
        /// Publiczny konstruktor do tworzenia obiektu z odpowiedzią i opcjonalnymi rekomendacjami.
        /// </summary>
        /// <param name="answer">Odpowiedź wygenerowana przez agenta</param>
        /// <param name="recommendedProducts">
        /// Lista rekomendowanych produktów (opcjonalna). Jeśli null, tworzona jest pusta lista.
        /// </param>
        public WriterResult(string answer, IReadOnlyList<Product>? recommendedProducts = null)
        {
            Answer = answer;

            // Jeśli nie podano listy produktów, ustaw pustą listę
            RecommendedProducts = recommendedProducts ?? new List<Product>();
        }
    }
}
