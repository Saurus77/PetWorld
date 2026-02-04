using PetWorld.Application.DTO;

namespace PetWorld.Application.Services
{
    /// <summary>
    /// Interfejs definiujący kontrakt dla serwisu czatu.
    /// Każda implementacja powinna umożliwiać zadawanie pytań
    /// i otrzymywanie odpowiedzi w formie DTO <see cref="ChatResponse"/>.
    /// </summary>
    public interface IChatService
    {
        /// <summary>
        /// Zadaje pytanie do systemu i otrzymuje odpowiedź.
        /// </summary>
        /// <param name="question">Pytanie od klienta</param>
        /// <returns>
        /// Obiekt <see cref="ChatResponse"/> zawierający odpowiedź
        /// oraz liczbę iteracji Writer-Critic potrzebnych do zatwierdzenia odpowiedzi.
        /// </returns>
        Task<ChatResponse> AskAsync(string question);
    }
}
