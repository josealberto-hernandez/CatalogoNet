using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Categories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll(CancellationToken cancellationToken);

        void Add(Category category);

        Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
