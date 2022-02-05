using System;

namespace Biblioteca.Core.Domain
{
    public class Autor
    {
        public int Id { get; private set; }
        public string NombreCompleto { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string CiudadProcedencia { get; private set; }
        public string CorreoElectronico { get; private set; }
    }

}
