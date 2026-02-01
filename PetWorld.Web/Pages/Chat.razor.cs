using Microsoft.AspNetCore.Components;
using PetWorld.Application.Services;

namespace PetWorld.Web.Pages
{
    public partial class Chat : ComponentBase
    {
        [Inject] private IChatService ChatService { get; set; } = default!;
        private string UserQuestion { get; set; } = string.Empty;
        private string? ResponseText { get; set; }
        private int IterationCount { get; set; }
        private bool IsProcessing { get; set; } = false;

        private async Task SendQuestion()
        {
            if (string.IsNullOrWhiteSpace(UserQuestion)) return;

            IsProcessing = true;
            ResponseText = null;

            var result = await ChatService.AskAsync(UserQuestion);

            ResponseText = result.Answer;
            IterationCount = result.Iterations;

            IsProcessing = false;
        }
    }
}
