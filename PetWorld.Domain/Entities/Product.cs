namespace PetWorld.Domain.Entities
{
    /// <summary>
    /// Encja reprezentująca produkt w sklepie PetWorld.
    /// Zawiera wszystkie informacje potrzebne do rekomendacji produktów klientowi.
    /// </summary>
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public decimal Price { get; private set; }

        /// <summary>
        /// Chroniony konstruktor wymagany np. przez ORM (Entity Framework)
        /// </summary>
        protected Product() { }

        /// <summary>
        /// Tworzy nowy produkt z podaną nazwą, opisem, kategorią i ceną.
        /// Automatycznie generuje Id.
        /// </summary>
        /// <param name="name">Nazwa produktu</param>
        /// <param name="description">Opis produktu</param>
        /// <param name="category">Kategoria produktu</param>
        /// <param name="price">Cena produktu</param>
        public Product(string name, string description, string category, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }
    }
}
