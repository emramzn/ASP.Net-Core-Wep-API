using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByTitle(string title);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);

        Task DeleteProductAsync(int id);

    }
}
