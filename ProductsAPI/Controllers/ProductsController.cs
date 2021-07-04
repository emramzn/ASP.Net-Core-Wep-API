using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Business.Abstract;
using Product.Business.Concrete;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _ProductService;
        public ProductsController(IProductService productService)
        {
            _ProductService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _ProductService.GetAllProducts();
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product.Product product)
        {
            var productAdd = await _ProductService.AddProduct(product);
            return Ok(productAdd);

        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _ProductService.GetProductById(id);
            if (product != null)
            {
                return Ok(product); // 200 + data
            }
            return NotFound(); // 404 
        }
        [HttpGet]
        [Route("[action]/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var product = await _ProductService.GetProductByTitle(title);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product.Product product)
        {
            if (await _ProductService.UpdateProduct(product) != null)
            {
                return Ok(await _ProductService.UpdateProduct(product));
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _ProductService.GetProductById(id) != null)
            {
                await _ProductService.DeleteProduct(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
