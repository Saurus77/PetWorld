using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Application.Abstractions.AI
{
    public interface ICriticAgent
    {
        Task<CriticResult> CritiqueAsync(string userQuestion, string Answer);
    }
}
