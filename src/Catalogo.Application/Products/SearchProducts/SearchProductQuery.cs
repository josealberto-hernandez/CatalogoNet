using Catalogo.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.SearchProducts
{
    public sealed class SearchProductQuery : IRequest<Product>
    {
        public string? Code { get; set; }

    }
}
