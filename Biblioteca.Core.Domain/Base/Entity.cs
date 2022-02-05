using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Base
{
    public abstract class Entity<T> : BaseEntity,IEntity<T>
    {
        public virtual T Id { get; }
    }
}
