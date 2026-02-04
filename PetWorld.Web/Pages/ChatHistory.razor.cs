using Microsoft.AspNetCore.Components;
using PetWorld.Application.Services;
using PetWorld.Domain.Entities;

namespace PetWorld.Web.Pages
{
    /// <summary>
    /// Klasa bazowa komponentu historii czatu Blazor.
    /// Odpowiada za pobranie wszystkich wpisów z bazy.
    /// </summary>
    public class ChatHistoryBase : ComponentBase
    {
        /// <summary>
        /// Serwis historii czatu wstrzykiwany przez Blazor.
        /// </summary>
        [Inject] protected IChatHistoryService ChatHistoryService { get; set; } = default!;

        /// <summary>
        /// Lista wszystkich wpisów historii czatu pobrana z bazy.
        /// </summary>
        protected IReadOnlyList<ChatHistoryEntry>? History;

        /// <summary>
        /// Metoda wywoływana podczas inicjalizacji komponentu.
        /// Pobiera wszystkie wpisy historii czatu z serwisu.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            History = await ChatHistoryService.GetAllAsync();
        }
    }
}
