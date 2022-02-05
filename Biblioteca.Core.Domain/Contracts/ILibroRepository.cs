using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Contracts
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetAllFullAsync();
    }
}
