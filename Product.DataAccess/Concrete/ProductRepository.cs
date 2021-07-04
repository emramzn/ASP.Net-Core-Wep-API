using Microsoft.EntityFrameworkCore;
using Product.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> AddProduct(Product product)
        {
            using (var productDbContext = new ProductDBContext())
            {
                productDbContext.Products.Add(product);
                await productDbContext.SaveChangesAsync();
                return product;
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            using (var productDbContext = new ProductDBContext())
            {
                var deletedProduct = await GetProductById(id);
                productDbContext.Products.Remove(deletedProduct);
                await productDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            using (var productDbContext = new ProductDBContext())
            {
                return await productDbContext.Products.ToListAsync();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            using (var productDbContext = new ProductDBContext())
            {
                return await productDbContext.Products.FindAsync(id);
            }
        }

        public async Task<Product> GetProductByTitle(string title)
        {
            using (var productDbContext = new ProductDBContext())
            {
                return await productDbContext.Products.FirstOrDefaultAsync(a => a.productTitle.ToLower() == title.ToLower());
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            using (var productDbContext = new ProductDBContext())
            {
                productDbContext.Products.Update(product);
                await productDbContext.SaveChangesAsync();
                return product;
            }
        }

    }
}
