using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Domain.Entities;

namespace PetWorld.Application.Agents
{
    public interface IWriterAgent
    {
        Task<string> GenerateAnswerAsync(
            string question,
            IReadOnlyList<Product> products,
            string? criticFeedback = null);
    }
}
