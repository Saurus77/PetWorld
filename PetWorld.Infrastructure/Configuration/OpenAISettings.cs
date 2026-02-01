using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Infrastructure.Configuration
{
    public class OpenAISettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string ModelName { get; set; } = "gpt-4o-mini";
    }
}
