using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    [HttpGet]
       public async Task<ActionResult<List<Product>>> GetProducts()
       {
           var result = await _productRepository.GetProductsAsync();
           return Ok(result);
       } 

       [HttpGet("{id}")]
       public async Task<ActionResult<Product>> GetProduct(int id)
       {
           return await _productRepository.GetProductByIdAsync(id);
       }

       [HttpGet("brands")]
       public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
       {
           var result = await _productRepository.GetProductBrandsAsync();
           return Ok(result);
       }
       [HttpGet("types")]
       public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
       {
           var result = await _productRepository.GetProductTypesAsync();
           return Ok(result);
       } 
 
 
    }
}