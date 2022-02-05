using Biblioteca.Core.Domain;
using Biblioteca.Core.Domain.Contracts;
using Biblioteca.Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Data.Repositories
{
    public class EditorialRepository : GenericRepository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(IDbContext context):base(context)
        {
        }
        public async Task<Editorial> FindIncludeLibroAsync(int id)
        {
            return await _dbset.Include(t => t.Libros).FirstOrDefaultAsync(t=>t.Id==id);
        }
    }
}
