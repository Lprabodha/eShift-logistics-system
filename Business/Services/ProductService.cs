using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productService;

        public ProductService(IProductRepository productService)
        {
            _productService = productService;
        }

        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
           return _productService.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }
    }
}
