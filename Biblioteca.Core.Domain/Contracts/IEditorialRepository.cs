using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Contracts
{
    public interface IEditorialRepository
    {
        Task<Editorial> FindIncludeLibroAsync(int id);
    }
}
