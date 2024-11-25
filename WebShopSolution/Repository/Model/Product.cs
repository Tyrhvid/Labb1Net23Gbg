namespace Repository.Model
{
    // The Product model represents a product in the web shop
    public class Product
    {
        public int Id { get; set; } // Unique identifier for the product

        public string Name { get; set; } // Name of the product

        public int CategoryId { get; set; } // Foreign key to the product's category

        public string Description { get; set; } // Optional: A brief description of the product

        public int Price { get; set; } // Price of the product

        public int Stock { get; set; } // Quantity available in stock

        public DateTime CreatedAt { get; set; } // When the product was created
        public DateTime UpdatedAt { get; set; } // When the product was last updated
    }
}
