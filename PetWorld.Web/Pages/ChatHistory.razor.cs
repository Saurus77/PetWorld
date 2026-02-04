using Microsoft.AspNetCore.Components;
using PetWorld.Application.Services;
using PetWorld.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetWorld.Web.Pages
{
    public class ChatHistoryBase : ComponentBase
    {
        [Inject] protected IChatHistoryService ChatHistoryService { get; set; } = default!;

        protected IReadOnlyList<ChatHistoryEntry>? History;

        protected override async Task OnInitializedAsync()
        {
            History = await ChatHistoryService.GetAllAsync();
        }
    }
}
