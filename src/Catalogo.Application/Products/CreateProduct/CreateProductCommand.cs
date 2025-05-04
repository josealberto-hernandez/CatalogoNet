using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Products.CreateProduct
{
   public sealed record CreateProductCommand(
       string Name,  
       string Description, 
       decimal Price,
       Guid CategoryId) : IRequest<Guid>;
    
    
}
