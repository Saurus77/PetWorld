using Microsoft.AspNetCore.Components;
using PetWorld.Application.Services;
using System.Threading.Tasks;

namespace PetWorld.Web.Pages
{
    public class ChatBase : ComponentBase
    {
        [Inject] protected IChatService ChatService { get; set; } = default!;

        protected string UserQuestion = string.Empty;
        protected string? ResponseText;
        protected int IterationCount;
        protected bool IsProcessing;

        protected async Task SendQuestion()
        {
            if (string.IsNullOrWhiteSpace(UserQuestion)) return;

            IsProcessing = true;
            ResponseText = null;

            try
            {
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
