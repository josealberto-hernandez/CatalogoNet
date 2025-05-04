using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.AllProducts
{
    internal sealed class AllProductsQueryHandler : IRequestHandler<AllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productrepository;

        public AllProductsQueryHandler(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public async Task<List<ProductDTO>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
        {
          var products = await _productrepository.GetAll(cancellationToken);
          return products.ConvertAll(p => p.ToDTO(request.Context!));
        }
    }
}
