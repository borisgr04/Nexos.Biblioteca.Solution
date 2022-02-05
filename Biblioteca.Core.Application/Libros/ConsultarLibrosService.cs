using Biblioteca.Core.Application.Autores;
using Biblioteca.Core.Domain;
using Biblioteca.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Core.Application.Libros
{
    public class ConsultarLibrosService : IRequestHandler<ConsultarLibrosRequest, ConsultarLibrosResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultarLibrosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ConsultarLibrosResponse> Handle(ConsultarLibrosRequest request, CancellationToken cancellationToken)
        {
            var libros = await _unitOfWork.LibroRepository.GetAllFullAsync();
            var librosDto = libros.Select(l => new LibroDto(l)).ToList();
            return new ConsultarLibrosResponse(librosDto);
        }

    }

    public record ConsultarLibrosRequest : IRequest<ConsultarLibrosResponse>
    {
       
    }
    public record ConsultarLibrosResponse
    {
        public ConsultarLibrosResponse(List<LibroDto> libros)
        {
            Libros = libros;
        }
        public List<LibroDto> Libros { get; set; }
    }

    public class LibroDto 
    {
        public LibroDto(Libro libro)
        {
            Titulo = libro.Titulo;
            Anio = libro.Anio.ToString();
            Genero = libro.Genero;
            NumeroPaginas = libro.NumeroPaginas;
            Editorial = libro.Editorial.Nombre;
            Autor = libro.Autor.NombreCompleto;
        }

        public string Titulo { get; set; }
        public string Anio { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
    }

}
