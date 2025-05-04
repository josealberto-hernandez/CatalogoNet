using Catalogo.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.AllProducts
{
    public sealed class AllProductsQuery : IRequest<List<ProductDTO>>
    {
        public HttpContext? Context { get; set; }
    }
}
