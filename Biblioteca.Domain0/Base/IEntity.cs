using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Base
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}
