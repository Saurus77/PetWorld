namespace PetWorld.Application.Agents
{
    /// <summary>
    /// Interfejs definiujący kontrakt dla Critic Agenta.
    /// Każda implementacja powinna potrafić ocenić odpowiedź wygenerowaną przez Writer Agenta.
    /// </summary>
    public interface ICriticAgent
    {
        /// <summary>
        /// Asynchronicznie ocenia odpowiedź pod kątem zgodności z wymaganiami.
        /// </summary>
        /// <param name="question">Pytanie zadane przez klienta</param>
        /// <param name="answer">Odpowiedź wygenerowana przez Writer Agenta</param>
        /// <returns>
        /// Obiekt <see cref="CriticResult"/> zawierający informację,
        /// czy odpowiedź została zatwierdzona oraz ewentualny feedback.
        /// </returns>
        Task<CriticResult> EvaluateAsync(string question, string answer);
    }
}
