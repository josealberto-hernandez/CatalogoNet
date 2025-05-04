using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalogo.Application.Products.SearchProducts;

public sealed class SearchProductQuery : IRequest<ProductDTO>
{
   public string? Code {get;set;}
   public HttpContext Context { get;set;}
}