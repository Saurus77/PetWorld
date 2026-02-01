using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Application.Abstractions.AI
{
    public class CriticResult
    {
        public bool Approved { get; init; }
        public string Feedback { get; init; } = string.Empty;
    }
}
