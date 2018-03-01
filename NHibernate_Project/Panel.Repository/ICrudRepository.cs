using System.Collections.Generic;

namespace Panel.Repository
{
    public interface ICrudRepository<T>
    {
        void Insert(T entities);
        void Update(T entities);
        void Delete(T entities);
        T GetById(int id);
        IList<T> GetList();
    }
}