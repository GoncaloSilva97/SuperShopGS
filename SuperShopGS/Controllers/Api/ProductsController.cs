using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperShopGS.Data;

namespace SuperShopGS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;


        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }


        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_productRepository.GetAllWithUsers());
        }


    }
}
