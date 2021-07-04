using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Business.Abstract;
using Product.Business.Concrete;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDataController : ControllerBase
    {
        private IProductService _ProductService;

        public FakeDataController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        public async Task<List<Product.Product>> CreateProduct()
        {
            var productList = await _ProductService.GetAllProducts();
            if (productList.Count <= 1)
            {
                var newProductList=FakeData.GetProducts();
                for (int i = 0; i < newProductList.Count; i++)
                {
                    await _ProductService.AddProduct(newProductList[i]);
                }
            }
            return productList;
        }

    }
}
