using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class ProductRepository : IProductRepository
    {

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        public void AddProduct(Product product)
        {
            string query = @"
                INSERT INTO products (name, default_weight, default_dimensions, is_fragile) 
                VALUES (@name, @default_weight, @default_dimensions, @is_fragile)";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@default_weight", product.DefaultWeight);
                command.Parameters.AddWithValue("@default_dimensions", product.DefaultDimensions);
                command.Parameters.AddWithValue("@is_fragile", product.IsFragile);
            });
        }

        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        public void UpdateProduct(Product product)
        {
            string query = @"
                UPDATE products SET 
                name = @name, 
                default_weight = @default_weight, 
                default_dimensions = @default_dimensions, 
                is_fragile = @is_fragile 
                WHERE id = @id";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@default_weight", product.DefaultWeight);
                command.Parameters.AddWithValue("@default_dimensions", product.DefaultDimensions);
                command.Parameters.AddWithValue("@is_fragile", product.IsFragile);
            });
        }

        /// <summary>
        /// Deletes a product from the database by its ID.
        /// </summary>
        public bool DeleteProduct(int id)
        {
            string query = "DELETE FROM products WHERE id = @id";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        public List<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();
            string query = "SELECT * FROM products";
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                DefaultWeight = reader.IsDBNull(reader.GetOrdinal("default_weight")) ? (decimal?)null : reader.GetDecimal("default_weight"),
                                DefaultDimensions = reader.IsDBNull(reader.GetOrdinal("default_dimensions")) ? null : reader.GetString("default_dimensions"),
                                IsFragile = reader.GetBoolean("is_fragile")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving drivers", ex);
                }
            }
            return products;
        }

        /// <summary>
        /// Retrieves a single product by its unique ID.
        /// </summary>
        public Product GetProductById(int id)
        {
            string query = "SELECT * FROM products WHERE id = @id";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                DefaultWeight = reader.IsDBNull(reader.GetOrdinal("default_weight")) ? (decimal?)null : reader.GetDecimal("default_weight"),
                                DefaultDimensions = reader.IsDBNull(reader.GetOrdinal("default_dimensions")) ? null : reader.GetString("default_dimensions"),
                                IsFragile = reader.GetBoolean("is_fragile")
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if a product name already exists for any other product.
        /// </summary>
        public bool IsNameExists(string name, int productIdToExclude)
        {
            string query = "SELECT COUNT(1) FROM products WHERE name = @name AND id != @id";
            var result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@name", name),
                new MySqlParameter("@id", productIdToExclude));
            return Convert.ToInt64(result) > 0;
        }
    }
}
