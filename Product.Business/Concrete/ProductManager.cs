using Product.Business.Abstract;
using Product.DataAccess.Abstract;
using Product.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _ProductRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        public async Task<Product> AddProduct(Product product)
        {
            return await _ProductRepository.AddProduct(product);
        }
        public async Task DeleteProduct(int id)
        {
            await _ProductRepository.DeleteProductAsync(id);
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _ProductRepository.GetAllProducts();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _ProductRepository.GetProductById(id);
        }

        public async Task<Product> GetProductByTitle(string title)
        {
            return await  _ProductRepository.GetProductByTitle(title);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return  await _ProductRepository.UpdateProduct(product);
        }

      
    }
}
