using Catalogo.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.SearchProducts
{
    internal sealed class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public SearchProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByCode(request.Code!, cancellationToken);

            return product!;
        }
    }
}
