using Catalogo.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly CatalogoDbContext dbContext;

        protected Repository(CatalogoDbContext context)
        {
            dbContext = context;
        }
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            dbContext.Add(entity);            
        }
    }
}
