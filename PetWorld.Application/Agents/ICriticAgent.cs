using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Application.Agents
{
    public interface ICriticAgent
    {
        Task<CriticResult> EvaluateAsync(
            string question,
            string answer);
    }
}
