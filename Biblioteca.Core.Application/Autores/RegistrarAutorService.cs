using Biblioteca.Core.Domain;
using Biblioteca.Domain.Base;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Core.Application.Autores
{
    public class RegistrarAutorService : IRequestHandler<RegistrarAutorRequest, RegistrarAutorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarAutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RegistrarAutorResponse> Handle(RegistrarAutorRequest request, CancellationToken cancellationToken)
        {
            //falta validar más
            var autorNuevo = new Autor()
            {
                NombreCompleto = request.NombreCompleto,
                FechaNacimiento = request.FechaNacimiento,
                CiudadProcedencia = request.CiudadProcedencia,
                CorreoElectronico = request.CorreoElectronico
            };
            _unitOfWork.GenericRepository<Autor>().Add(autorNuevo);
            var filas=await _unitOfWork.CommitAsync(cancellationToken);

            return new RegistrarAutorResponse($"Se realizó la operación satisfactoriamente. Registros afectados {filas}");
        }
    }

    public record RegistrarAutorRequest : IRequest<RegistrarAutorResponse>
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }
    }
    public record RegistrarAutorResponse
    {
        public RegistrarAutorResponse(string mensaje)
        {
            Mensaje = mensaje;
        }
        public string Mensaje { get; set; }
    }


}
