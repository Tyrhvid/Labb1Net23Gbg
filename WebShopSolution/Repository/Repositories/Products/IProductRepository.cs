using Repository.Model;

namespace Repository.Repositories.Products
{
    // Interface for product repository following the Repository Pattern
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Updates the stock of a product by the specified quantity.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="quantity">The quantity to add or subtract from the stock. Use negative values to decrease stock.</param>
        /// <returns>True if the stock was updated successfully; otherwise, false.</returns>
        bool UpdateProductStock(int productId, int quantity);

        /// <summary>
        /// Checks if a product exists with the specified ID.
        /// </summary>
        /// <param name="productId">The ID of the product to check.</param>
        /// <returns>True if the product exists; otherwise, false.</returns>
        bool ProductExists(int productId);

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, or null if not found.</returns>
        Product GetById(int productId);
    }
}
