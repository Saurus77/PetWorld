using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Domain.Entities
{
    // Encja pilnująca spójności danych produktu
    public class Product
    {
        // Set jest prywatny, aby zapobiec modyfikacjom z zewnątrz
        // Zmiany idą poprzez logikę domeny
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string Description { get; private set; } = string.Empty;

        protected Product() { }

        public Product(string name, string category, decimal price, string description)
        {
            Name = name;
            Category = category;
            Price = price;
            Description = description;
        }
    }
}
