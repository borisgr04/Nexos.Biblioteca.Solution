using System.Collections.Generic;

namespace Biblioteca.Core.Application.Autores
{
    public interface IValidateModel
    {
        void AddError(string errorMessage);
        bool IsValid { get; }
        List<string> ToListText();
        bool TryValidateObject(object instance);
    }
}