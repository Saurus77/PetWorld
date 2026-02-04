using PetWorld.Application.DTO;
using PetWorld.Application.Orchestration;

namespace PetWorld.Application.Services
{
    /// <summary>
    /// Serwis odpowiedzialny za obsługę pytań od klientów.
    /// Łączy UI z WriterCriticOrchestrator i zwraca gotowy DTO do wyświetlenia.
    /// </summary>
    public class ChatService : IChatService
    {
        // Orchestrator, który steruje procesem Writer-Critic
        private readonly WriterCriticOrchestrator _orchestrator;

        /// <summary>
        /// Konstruktor wstrzykujący orchestratora.
        /// </summary>
        /// <param name="orchestrator">Orchestrator Writer-Critic</param>
        public ChatService(
            WriterCriticOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }


        /// <summary>
        /// Zadaje pytanie do systemu i otrzymuje odpowiedź.
        /// </summary>
        /// <param name="question">Pytanie od klienta</param>
        /// <returns>
        /// DTO <see cref="ChatResponse"/> zawierający odpowiedź i liczbę iteracji
        /// potrzebnych do zatwierdzenia odpowiedzi.
        /// </returns>
        public async Task<ChatResponse> AskAsync(string question)
        {
            // Wywołanie orchestratora, który wykona workflow Writer-Critic
            var chatEntry = await _orchestrator.ExecuteAsync(question);

            // Tworzenie DTO dla UI
            return new ChatResponse
            {
                Answer = chatEntry.Answer,
                Iterations = chatEntry.Iterations
            };
        }
    }
}
