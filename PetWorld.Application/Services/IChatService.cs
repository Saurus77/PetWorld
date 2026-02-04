using System.Threading.Tasks;
using PetWorld.Application.DTO;

namespace PetWorld.Application.Services
{
    public interface IChatService
    {
        Task<ChatResponse> AskAsync(string question);
    }
}
