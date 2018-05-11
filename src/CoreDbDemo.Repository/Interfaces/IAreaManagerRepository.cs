using CoreDbDemo.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IAreaManagerRepository
    {
        Task<AreaManagerDbo> Get(int id);
        Task<IEnumerable<AreaManagerDbo>> GetAll();
        Task<AreaManagerDbo> AddOrUpdate(AreaManagerDbo brand);
    }
}