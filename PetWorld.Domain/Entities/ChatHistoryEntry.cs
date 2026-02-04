namespace PetWorld.Domain.Entities
{
    /// <summary>
    /// Encja reprezentująca jeden wpis w historii czatu.
    /// Zawiera pytanie klienta, odpowiedź systemu oraz liczbę iteracji Writer-Critic.
    /// </summary>
    public class ChatHistoryEntry
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Question { get; private set; } = string.Empty;
        public string Answer { get; private set; } = string.Empty;
        public int Iterations { get; private set; }

        /// <summary>
        /// Chroniony konstruktor wymagany np. przez ORM (Entity Framework)
        /// </summary>
        protected ChatHistoryEntry() { }

        /// <summary>
        /// Tworzy nowy wpis historii czatu z pytaniem, odpowiedzią i liczbą iteracji.
        /// Automatycznie generuje Id i CreatedAt.
        /// </summary>
        /// <param name="question">Pytanie klienta</param>
        /// <param name="answer">Odpowiedź systemu</param>
        /// <param name="iterations">Liczba iteracji Writer-Critic</param>
        public ChatHistoryEntry(string question, string answer, int iterations)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Question = question;
            Answer = answer;
            Iterations = iterations;
        }
    }
}
