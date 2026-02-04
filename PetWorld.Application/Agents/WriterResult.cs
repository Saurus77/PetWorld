using PetWorld.Domain.Entities;
using System.Collections.Generic;

namespace PetWorld.Application.Agents
{
    public class WriterResult
    {
        public string Answer { get; set; } = string.Empty;

        // Lista produktów rekomendowanych przez agenta (opcjonalnie)
        public IReadOnlyList<Product> RecommendedProducts { get; set; } = new List<Product>();

        protected WriterResult() { }

        public WriterResult(string answer, IReadOnlyList<Product>? recommendedProducts = null)
        {
            Answer = answer;
            RecommendedProducts = recommendedProducts ?? new List<Product>();
        }
    }
}
