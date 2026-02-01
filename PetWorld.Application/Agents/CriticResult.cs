using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Application.Agents
{
    public class CriticResult
    {
        public bool Approved { get; set; }
        public string Feedback { get; set; } = string.Empty;
    }
}
