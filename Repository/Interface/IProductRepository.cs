using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
   public interface IProductRepository
    {
        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">The product object to add.</param>
        void AddProduct(Product product);

        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        /// <param name="product">The product object with updated information.</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Deletes a product from the database by its ID.
        /// </summary>
        /// <param name="id">The primary key of the product to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        bool DeleteProduct(int id);

        /// <summary>
        /// Retrieves a single product by its unique ID.
        /// </summary>
        /// <param name="id">The primary key of the product.</param>
        /// <returns>The found Product object, or null if not found.</returns>
        Product GetProductById(int id);

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Checks if a product name already exists, excluding a specific product ID.
        /// </summary>
        /// <param name="name">The name to check for duplicates.</param>
        /// <param name="productIdToExclude">The ID of the current product to exclude from the check (used for editing).</param>
        /// <returns>True if the name exists, otherwise false.</returns>
        bool IsNameExists(string name, int productIdToExclude);

    }
}
