using System.Collections.Generic;

namespace csharp_contracted.Interfaces
{
    public interface IRepository<T, Tid>
    {
        List<T> GetAll();

        T GetById(Tid id);

        T Create(T newData);

        void Edit(T update);

        void Delete(Tid objectId);
    }
}