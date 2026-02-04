namespace PetWorld.Application.Agents
{
    /// <summary>
    /// Reprezentuje wynik oceny odpowiedzi wygenerowanej przez Writer Agenta.
    /// Klasa używana przez Critic Agenta do informowania, czy odpowiedź jest zatwierdzona
    /// i przekazania ewentualnego feedbacku.
    /// </summary>
    public class CriticResult
    {
        /// <summary>
        /// Określa, czy odpowiedź została zatwierdzona przez Critica.
        /// true = odpowiedź poprawna, false = wymaga poprawy
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Tekstowy feedback od Critica, wyjaśniający decyzję.
        /// Może zawierać wskazówki do poprawy odpowiedzi.
        /// </summary>
        public string Feedback { get; set; } = string.Empty;

        /// <summary>
        /// Konstruktor chroniony, potrzebny np. do serializacji/deserializacji.
        /// Nie pozwala tworzyć pustych instancji na zewnątrz.
        /// </summary>
        protected CriticResult() { }

        /// <summary>
        /// Publiczny konstruktor do tworzenia obiektu z gotowym wynikiem i feedbackiem.
        /// </summary>
        /// <param name="approved">Czy odpowiedź jest zatwierdzona</param>
        /// <param name="feedback">Opcjonalny feedback od Critica</param>
        public CriticResult(bool approved, string feedback)
        {
            // Przypisanie wartości do właściwości
            Approved = approved;
            Feedback = feedback;
        }
    }
}
