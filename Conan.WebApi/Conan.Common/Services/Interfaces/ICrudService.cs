using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Conan.Common.DTO;

namespace Conan.Common.Services.Interfaces
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task Insert(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int item);
    }
}