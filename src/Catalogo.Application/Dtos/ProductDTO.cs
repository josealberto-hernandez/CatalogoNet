using Catalogo.Domain.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Dtos
{

    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product, HttpContext context)
        {
            return new ProductDTO(
                product.Id,
                product.Name!,
                product.Description!,
                product.Price ?? product.Price!.Value,
                $"{context.Request.Scheme}://{context.Request.Host}/Images/{product.ImageUrl}",
                product.Code!,
                product.CategoryId
                );
        }

    }
    public sealed record ProductDTO(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        string Code,
        Guid CategoryId
        );
}
