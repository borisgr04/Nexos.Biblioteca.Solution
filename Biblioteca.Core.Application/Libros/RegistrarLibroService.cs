using Biblioteca.Core.Application.Autores;
using Biblioteca.Core.Domain;
using Biblioteca.Domain.Base;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Core.Application.Libros
{
    public class RegistrarLibroService : IRequestHandler<RegistrarLibroRequest, RegistrarLibroResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarLibroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RegistrarLibroResponse> Handle(RegistrarLibroRequest request, CancellationToken cancellationToken)
        {
            ValidateModel validate = await ValidarAsync(request);

            if (!validate.IsValid)
            {
                throw new ValidationApplicationException(validate);
            }

            //falta validar más
            var libroNuevo = new Libro()
            {
                Titulo = request.Titulo,
                Anio = request.Anio,
                Genero = request.Genero,
                NumeroPaginas = request.NumeroPaginas,
                AutorId = request.AutorId,
                EditorialId = request.EditorialId,
            };
            _unitOfWork.GenericRepository<Libro>().Add(libroNuevo);
            var filas = await _unitOfWork.CommitAsync(cancellationToken);

            return new RegistrarLibroResponse($"Se realizó la operación satisfactoriamente. Registros afectados {filas}");
        }

        private async Task<ValidateModel> ValidarAsync(RegistrarLibroRequest request)
        {
            var validate = new ValidateModel();
            validate.TryValidateObject(request);
            var autor = _unitOfWork.GenericRepository<Autor>().Find(request.AutorId);
            if (autor == null)
            {
                validate.AddError("El autor no está registrado.");
            }
            var editorial = await _unitOfWork.EditorialRepository.FindIncludeLibroAsync(request.EditorialId);
            if (editorial == null)
            {
                validate.AddError("La editorial no está registrada.");
            }
            if (editorial != null && !editorial.TieneDisponibilidadDeRegistro())
            {
                validate.AddError($"No es permitido registrar más libros en la Editarial {editorial.Nombre}. La editorial tiene {editorial.MaximoLibrosRegistrados} máximo de libros para registrar.");
            }

            return validate;
        }

    }

    public record RegistrarLibroRequest : IRequest<RegistrarLibroResponse>
    {
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }

        public int EditorialId { get; set; }
        public int AutorId { get; set; }
    }
    public record RegistrarLibroResponse
    {
        public RegistrarLibroResponse(string mensaje)
        {
            Mensaje = mensaje;
        }
        public string Mensaje { get; set; }
    }


}
