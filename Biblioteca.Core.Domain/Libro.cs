using Biblioteca.Domain.Base;

namespace Biblioteca.Core.Domain
{
    public class Libro : Entity<int>, IAggregateRoot
    {
        public string Titulo { get; init; }
        public int Anio { get; init; }
        public string Genero { get; init; }
        public int NumeroPaginas { get; init; }

        public int EditorialId { get; init; }
        public int AutorId { get; init; }

        public Autor Autor { get; init; }
        public Editorial Editorial { get; init; }
    }

    

}
