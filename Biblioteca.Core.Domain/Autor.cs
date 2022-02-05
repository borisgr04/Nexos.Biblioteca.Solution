using Biblioteca.Domain.Base;
using System;

namespace Biblioteca.Core.Domain
{
    public class Autor : Entity<int>, IAggregateRoot
    {
        public string NombreCompleto { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public string CiudadProcedencia { get; init; }
        public string CorreoElectronico { get; init; }
    }

}
