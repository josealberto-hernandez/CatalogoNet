using Catalogo.Application.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        //http://localhost:5001/api/products/code/12345
        [HttpGet("code")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var query = new SearchProductQuery{Code = code};
            var product = await _sender.Send(query);

            return Ok(product);
        }
    }
}
