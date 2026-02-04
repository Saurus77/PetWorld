using Microsoft.AspNetCore.Components;
using PetWorld.Application.Services;

namespace PetWorld.Web.Pages
{
    /// <summary>
    /// Klasa bazowa komponentu czatu Blazor.
    /// Zawiera logikę wysyłania pytań do AI i odbierania odpowiedzi.
    /// </summary>
    public class ChatBase : ComponentBase
    {
        /// <summary>
        /// Serwis czatu (Writer + Critic) wstrzykiwany przez Blazor.
        /// </summary>
        [Inject] protected IChatService ChatService { get; set; } = default!;

        protected string UserQuestion = string.Empty;
        protected string? ResponseText;
        protected int IterationCount;
        protected bool IsProcessing;

        /// <summary>
        /// Wywoływane po kliknięciu przycisku "Wyślij"
        /// Wysyła pytanie do AI i pobiera odpowiedź
        /// </summary>
        protected async Task SendQuestion()
        {
            if (string.IsNullOrWhiteSpace(UserQuestion)) return;

            IsProcessing = true;
            ResponseText = null;

            try
            {
                // Wywołanie serwisu czatu
                var result = await ChatService.AskAsync(UserQuestion);

                ResponseText = result.Answer;
                IterationCount = result.Iterations;
            }
            finally
            {
                IsProcessing = false;
            }
        }
    }
}
