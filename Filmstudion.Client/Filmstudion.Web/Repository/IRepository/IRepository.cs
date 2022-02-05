using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmstudion.Web.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, int Id);
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<bool> CreateAsync(string url, T filmToCreate);
        Task<bool> UpdateAsync(string url, T filmToUpdate);
        Task<bool> DeleteAsync(string url, int Id);
    }
}
