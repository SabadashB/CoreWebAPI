using CoreBL;
using CoreBL.Models;
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
        private readonly ProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            ILogger<ProductsController> logger,
            ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if(product != null)
            {
                Guid createdGuid;
                try
                {
                    createdGuid = _productService.AddProduct(product);
                }
                catch (ArgumentException ex)
                {

                    return BadRequest(ex.Message);
                }
                

                return Created(product.Id.ToString(), product);
            }

            return BadRequest();
            
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts(Product user)
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            var product = _productService.GetProductByID(id);
            if(product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var successed = _productService.UpdateProduct(product);

            return StatusCode(successed ? 200 : 404);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productService.RemoveProduct(id);

            return StatusCode(product != null ? 200 : 404, product);

        }
    }
}
