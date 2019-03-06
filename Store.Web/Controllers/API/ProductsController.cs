using Microsoft.AspNetCore.Mvc;
using Store.Web.Data;

namespace Store.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepositiry)
        {
            this.productRepository = productRepositiry;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.productRepository.GetAll());
        }
    }
}
