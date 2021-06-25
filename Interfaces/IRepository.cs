using System.Collections.Generic;

namespace ShowsRepository.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);        
        void Insert(T entity);        
        void Delete(int id);        
        void Update(int id, T entity);
        int NextId();
    }
}