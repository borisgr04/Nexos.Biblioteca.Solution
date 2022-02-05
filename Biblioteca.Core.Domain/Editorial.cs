using Biblioteca.Domain.Base;
using System;
using System.Collections.Generic;

namespace Biblioteca.Core.Domain
{
    public class Editorial : Entity<int>, IAggregateRoot
    {
        public Editorial()
        {
            _libros = new List<Libro>();
        }
        public string Nombre { get; init; }
        public string DireccionCorrespondencia { get; init; }
        public string Telefono { get; init; }
        public string CorreoElectronico { get; init; }
        public int MaximoLibrosRegistrados { get; init; }
        public int LibroRegistrados => Libros.Count;
        
        private readonly List<Libro> _libros;
        public IReadOnlyCollection<Libro> Libros => _libros.AsReadOnly();

        public bool TieneDisponibilidadDeRegistro() => MaximoLibrosRegistrados != -1 && MaximoLibrosRegistrados == LibroRegistrados;
        
    }



}
