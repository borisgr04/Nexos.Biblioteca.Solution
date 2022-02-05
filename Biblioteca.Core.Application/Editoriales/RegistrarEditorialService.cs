using Biblioteca.Core.Domain;
using Biblioteca.Domain.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Core.Application.Editoriales
{
    public class RegistrarEditorialService : IRequestHandler<RegistrarEditorialRequest, RegistrarEditorialResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarEditorialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RegistrarEditorialResponse> Handle(RegistrarEditorialRequest request, CancellationToken cancellationToken)
        {
            //falta validar más
            var libroNuevo = new Editorial()
            {
                Nombre = request.Nombre,
                DireccionCorrespondencia = request.DireccionCorrespondencia,
                Telefono = request.Telefono,
                CorreoElectronico = request.CorreoElectronico,
                MaximoLibrosRegistrados = request.MaximoLibrosRegistrados,
            };
            _unitOfWork.GenericRepository<Editorial>().Add(libroNuevo);
            var filas = await _unitOfWork.CommitAsync(cancellationToken);

            return new RegistrarEditorialResponse($"Se realizó la operación satisfactoriamente. Registros afectados {filas}");
        }
    }

    public record RegistrarEditorialRequest : IRequest<RegistrarEditorialResponse>
    {
        public string Nombre { get; set; }
        public string DireccionCorrespondencia { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int MaximoLibrosRegistrados { get; set; }
    }
    public record RegistrarEditorialResponse
    {
        public RegistrarEditorialResponse(string mensaje)
        {
            Mensaje = mensaje;
        }
        public string Mensaje { get; set; }
    }


}
