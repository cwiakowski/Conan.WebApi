using System.Collections.Generic;
using System.Threading.Tasks;
using Conan.Data.Models;

namespace Conan.Data.Repositories.Interfaces
{
    public interface ICrudRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task Insert(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);
    }
}