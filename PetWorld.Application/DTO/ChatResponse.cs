namespace PetWorld.Application.DTO
{
    /// <summary>
    /// Obiekt Data Transfer Object (DTO) używany do przesyłania odpowiedzi czatu
    /// z warstwy Application do UI (Blazor).
    /// Zawiera gotową odpowiedź oraz liczbę iteracji Writer-Critic.
    /// </summary>
    public class ChatResponse
    {
        /// <summary>
        /// Tekst odpowiedzi wygenerowanej dla klienta.
        /// </summary>
        public string Answer { get; set; } = string.Empty;

        /// <summary>
        /// Liczba iteracji Writer-Critic potrzebnych do zatwierdzenia odpowiedzi.
        /// Maksymalnie 3 iteracje.
        /// </summary>
        public int Iterations { get; set; } = 0;
    }
}
