using ClassesTimetable.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassesTimetable.Core.Interfaces
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        object Teachers { get; }

        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
