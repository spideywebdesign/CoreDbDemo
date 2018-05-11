using CoreDbDemo.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreDbDemo.Repository.Interfaces
{
    public interface IBrandRepository
    {
        Task<BrandDbo> Get(int id);
        Task<IEnumerable<BrandDbo>> GetAll();
        Task<IEnumerable<BrandDbo>> GetByAreaManager(int id);
        Task<BrandDbo> AddOrUpdate(BrandDbo brand);
    }
}