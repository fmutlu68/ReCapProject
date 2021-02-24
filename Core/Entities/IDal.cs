using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public interface IDal<T>: IEntityRepository<T> where T : class, IEntity, new()
    {
    }
}
