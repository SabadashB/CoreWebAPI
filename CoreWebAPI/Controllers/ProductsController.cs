using Core1WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core1WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : ControllerBase
    {
        private static List<Product> _products;
        private readonly ILogger<ProductsController> _logger;

        static ProductsController()
        {
            _products = new List<Product>();
        }

        public ProductsController(
            ILogger<ProductsController> logger)
        {
            _logger = logger;

        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProducts(Product user)
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            Product product = _products.FirstOrDefault(user => user.Id == id);
            if(product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Product product)
        {
            var dbProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if(dbProduct != null)
            {
                var index = _products.IndexOf(dbProduct);
                _products[index] = product;
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            Product dbProduct = _products.FirstOrDefault(x => x.Id == id);
            if(dbProduct != null)
            {
                _products.Remove(dbProduct);

                return Ok(dbProduct);
            }

            return NotFound();
        }
    }
}
