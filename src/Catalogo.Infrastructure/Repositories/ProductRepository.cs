using Catalogo.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    internal sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogoDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
           return await dbContext.Set<Product>().ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByCode(string code, CancellationToken cancellationToken)
        {
           return await dbContext.Set<Product>().Where(p =>p.Code == code).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
