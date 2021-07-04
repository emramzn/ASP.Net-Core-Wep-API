using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    public class FakeData
    {
        public static List<Product.Product> _Products;
        public static List<Product.Product> GetProducts()
        {
            if (_Products == null)
            {
                _Products = new Faker<Product.Product>()
               .RuleFor(a => a.productDesc, b => b.Lorem.Sentence())
               .RuleFor(a => a.productTitle, b => b.Lorem.Sentence())
               .RuleFor(a => a.productPrice, b => b.Random.Decimal(14.02m, 999.26m)).Generate(100);

            }
            return _Products;
        }
    }
}
