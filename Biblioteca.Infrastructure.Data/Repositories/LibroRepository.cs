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
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        public LibroRepository(IDbContext context):base(context)
        {
        }
   
        public async Task<List<Libro>> GetAllFullAsync()
        {
            return await _dbset.Include(t => t.Autor).Include(t => t.Editorial).ToListAsync();
        }
    }
}
