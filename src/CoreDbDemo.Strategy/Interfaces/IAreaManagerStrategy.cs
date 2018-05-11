using CoreDbDemo.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Strategy.Interfaces
{
    public interface IAreaManagerStrategy
    {
        Task<AreaManager> Get(int id);
        Task<IEnumerable<AreaManager>> GetAll();
        Task<AreaManager> AddOrUpdate(AreaManager areaManager);
    }
}