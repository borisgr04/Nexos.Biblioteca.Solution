using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Application.Autores
{
    public class ValidationApplicationException : Exception
    {
        public List<string> Messages { get; private set; }
        public ValidationApplicationException() { }
        public ValidationApplicationException(ValidateModel validate) => Messages = validate.ToListText();
        public ValidationApplicationException(string message) => Messages.Add(message);
        public ValidationApplicationException(string message, Exception inner) : base(message, inner) { }
        protected ValidationApplicationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public ValidationApplicationException(List<string> mensajes)
        {
            Messages = mensajes;
        }
    }
}
