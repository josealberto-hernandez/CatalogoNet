using Catalogo.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogoDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
        {
            return await (from c in dbContext.Set<Category>() select c).ToListAsync(cancellationToken);
        }
    }
}
